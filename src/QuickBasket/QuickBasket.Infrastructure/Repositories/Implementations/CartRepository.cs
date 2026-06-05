using Dapper;
using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Application.Features.Carts.DTOs;
using QuickBasket.Application.Interfaces;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Domain.Entities;

namespace QuickBasket.Infrastructure.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly IDapperContext _context;

        public CartRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<CartResponseDto>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();

            const string cartSql = @"SELECT Id, UserId, SessionId, IsCheckedOut
                                    FROM Carts
                                    WHERE IsDeleted = 0";

            const string itemSql = @"SELECT Id, Quantity, UnitPrice, CartId, ProductId
                                    FROM CartItems
                                    WHERE IsDeleted = 0";

            var carts = (await connection.QueryAsync<CartResponseDto>(cartSql))
                .ToList();

            var items = (await connection.QueryAsync<CartItemResponseDto>(itemSql))
                .ToList();

            foreach (var cart in carts)
            {
                cart.Items = items
                    .Where(x => x.CartId == cart.Id)
                    .ToList();
            }

            return carts;
        }

        public async Task<CartResponseDto?> GetByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();

            const string cartSql = @"SELECT Id, UserId, SessionId, IsCheckedOut
                                    FROM Carts
                                    WHERE Id = @Id
                                    AND IsDeleted = 0";

            const string itemSql = @"SELECT Id, Quantity, UnitPrice, CartId, ProductId
                                    FROM CartItems
                                    WHERE CartId = @Id
                                    AND IsDeleted = 0";

            var cart =
                await connection.QueryFirstOrDefaultAsync<CartResponseDto>(
                    cartSql,
                    new { Id = id });

            if (cart == null)
                return null;

            var items =
                await connection.QueryAsync<CartItemResponseDto>(
                    itemSql,
                    new { Id = id });

            cart.Items = items.ToList();

            return cart;
        }

        public async Task<int> CreateCartAsync(Cart cart)
        {
            const string sql = @"INSERT INTO Carts
                            (UserId, SessionId, IsCheckedOut, CreatedAt, CreatedBy, IsDeleted)
                            VALUES
                            (@UserId, @SessionId, @IsCheckedOut, @CreatedAt, @CreatedBy, @IsDeleted);

                            SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, cart);
        }

        public async Task<int> UpdateCartAsync(Cart cart)
        {
            const string sql = @"UPDATE Carts SET
                                IsCheckedOut = COALESCE(@IsCheckedOut, IsCheckedOut),
                                ModifiedAt = @ModifiedAt,
                                ModifiedBy = @ModifiedBy
                             WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, cart);
        }

        public async Task<bool> DeleteCartAsync(int id)
        {
            const string sql = @"UPDATE Carts SET
                                IsDeleted = 1,
                                ModifiedAt = @ModifiedAt,
                                ModifiedBy = @ModifiedBy
                             WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            var affected = await connection.ExecuteAsync(sql, new
            {
                Id = id,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = "System"
            });

            return affected > 0;
        }
    }
}
