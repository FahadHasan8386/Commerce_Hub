using Dapper;
using QuickBasket.Application.Features.Orders.DTOs;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Application.Interfaces;

namespace QuickBasket.Infrastructure.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDapperContext _context;

        public OrderRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<OrderResponseDto>> GetAllAsync()
        {
            const string sql = @"SELECT
                                    Id,
                                    UserId,
                                    OrderDate,
                                    TotalAmount,
                                    OrderStatus,
                                    ShippingAddress,
                                    PaymentMethod
                                FROM Orders";

            using var connection = _context.CreateConnection();
            var orders = (await connection.QueryAsync<OrderResponseDto>(sql)).ToList();

            foreach (var order in orders)
            {
                order.Items = (await connection.QueryAsync<OrderItemResponseDto>(
                    @"SELECT
                        Id,
                        OrderId,
                        ProductId,
                        Quantity,
                        UnitPrice,
                        ProductName
                    FROM OrderItems
                    WHERE OrderId = @OrderId",
                    new { OrderId = order.Id })).ToList();
            }

            return orders;
        }

        public async Task<OrderResponseDto?> GetByIdAsync(int id)
        {
            const string orderSql = @"SELECT
                                        Id,
                                        UserId,
                                        OrderDate,
                                        TotalAmount,
                                        OrderStatus,
                                        ShippingAddress,
                                        PaymentMethod
                                    FROM Orders
                                    WHERE Id = @Id";

            const string itemSql = @"SELECT
                                        Id,
                                        OrderId,
                                        ProductId,
                                        Quantity,
                                        UnitPrice,
                                        ProductName
                                    FROM OrderItems
                                    WHERE OrderId = @OrderId";

            using var connection = _context.CreateConnection();
            var order = await connection.QueryFirstOrDefaultAsync<OrderResponseDto>(orderSql, new { Id = id });

            if (order == null)
            {
                return null;
            }

            order.Items = (await connection.QueryAsync<OrderItemResponseDto>(itemSql, new { OrderId = order.Id })).ToList();
            return order;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDto order)
        {
            const string orderSql = @"INSERT INTO Orders
                                        (UserId, OrderDate, TotalAmount, OrderStatus, ShippingAddress, PaymentMethod, CreatedAt)
                                      VALUES
                                        (@UserId, @OrderDate, @TotalAmount, @OrderStatus, @ShippingAddress, @PaymentMethod, @CreatedAt);
                                      SELECT CAST(SCOPE_IDENTITY() as int)";

            const string orderItemSql = @"INSERT INTO OrderItems
                                            (OrderId, ProductId, Quantity, UnitPrice, ProductName, CreatedAt)
                                          VALUES
                                            (@OrderId, @ProductId, @Quantity, @UnitPrice, @ProductName, @CreatedAt)";

            using var connection = _context.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var orderId = await connection.QuerySingleAsync<int>(orderSql, order, transaction);

                foreach (var item in order.Items)
                {
                    await connection.ExecuteAsync(orderItemSql, new
                    {
                        OrderId = orderId,
                        item.ProductId,
                        item.Quantity,
                        item.UnitPrice,
                        item.ProductName,
                        CreatedAt = DateTime.UtcNow
                    }, transaction);
                }

                transaction.Commit();
                return orderId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<int> UpdateOrderAsync(UpdateOrderDto order)
        {
            const string orderSql = @"UPDATE Orders SET
                                        UserId = @UserId,
                                        OrderDate = @OrderDate,
                                        TotalAmount = @TotalAmount,
                                        OrderStatus = @OrderStatus,
                                        ShippingAddress = @ShippingAddress,
                                        PaymentMethod = @PaymentMethod
                                      WHERE Id = @Id";

            const string deleteItemsSql = @"DELETE FROM OrderItems WHERE OrderId = @OrderId";

            const string addItemSql = @"INSERT INTO OrderItems
                                            (OrderId, ProductId, Quantity, UnitPrice, ProductName, CreatedAt)
                                        VALUES
                                            (@OrderId, @ProductId, @Quantity, @UnitPrice, @ProductName, @CreatedAt)";

            using var connection = _context.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                var rowsAffected = await connection.ExecuteAsync(orderSql, order, transaction);
                if (rowsAffected == 0)
                {
                    transaction.Rollback();
                    return 0;
                }

                await connection.ExecuteAsync(deleteItemsSql, new { OrderId = order.Id }, transaction);

                foreach (var item in order.Items)
                {
                    await connection.ExecuteAsync(addItemSql, new
                    {
                        OrderId = order.Id,
                        item.ProductId,
                        item.Quantity,
                        item.UnitPrice,
                        item.ProductName,
                        CreatedAt = DateTime.UtcNow
                    }, transaction);
                }

                transaction.Commit();
                return rowsAffected;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            const string deleteItemsSql = @"DELETE FROM OrderItems WHERE OrderId = @OrderId";
            const string deleteOrderSql = @"DELETE FROM Orders WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                await connection.ExecuteAsync(deleteItemsSql, new { OrderId = id }, transaction);
                var rowsAffected = await connection.ExecuteAsync(deleteOrderSql, new { Id = id }, transaction);
                transaction.Commit();
                return rowsAffected > 0;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
