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
            const string sql = @"
                                SELECT
                                    c.Id,
                                    c.UserId,
                                    c.SessionId,
                                    c.IsCheckedOut,

                                    ci.Id,
                                    ci.Quantity,
                                    ci.UnitPrice,
                                    ci.CartId,
                                    ci.ProductId

                                FROM Carts c

                                LEFT JOIN CartItems ci
                                    ON c.Id = ci.CartId
                                    AND ci.IsDeleted = 0

                                WHERE c.IsDeleted = 0";

            using var connection = _context.CreateConnection();

            var cartDictionary = new Dictionary<int, CartResponseDto>();

            await connection.QueryAsync<
                CartResponseDto,
                CartItemResponseDto,
                CartResponseDto>(
                sql,
                (cart, item) =>
                {
                    if (!cartDictionary.TryGetValue(cart.Id, out var existingCart))
                    {
                        existingCart = cart;
                        existingCart.Items = new List<CartItemResponseDto>();

                        cartDictionary.Add(cart.Id, existingCart);
                    }

                    if (item != null && item.Id > 0)
                    {
                        existingCart.Items.Add(item);
                    }

                    return existingCart;
                },
                splitOn: "Id"
            );

            return cartDictionary.Values.ToList();
        }

        public async Task<CartResponseDto?> GetByIdAsync(int id)
        {
            const string sql = @"
                                SELECT
                                    c.Id,
                                    c.UserId,
                                    c.SessionId,
                                    c.IsCheckedOut,

                                    ci.Id,
                                    ci.Quantity,
                                    ci.UnitPrice,
                                    ci.CartId,
                                    ci.ProductId

                                FROM Carts c
                                LEFT JOIN CartItems ci
                                    ON c.Id = ci.CartId
                                    AND ci.IsDeleted = 0

                                WHERE c.Id = @Id
                                AND c.IsDeleted = 0";

            using var connection = _context.CreateConnection();

            var cartDictionary = new Dictionary<int, CartResponseDto>();

            var result = await connection.QueryAsync<
                CartResponseDto,
                CartItemResponseDto,
                CartResponseDto>(
                sql,
                (cart, item) =>
                {
                    if (!cartDictionary.TryGetValue(cart.Id, out var existingCart))
                    {
                        existingCart = cart;
                        existingCart.Items = new List<CartItemResponseDto>();
                        cartDictionary.Add(cart.Id, existingCart);
                    }

                    if (item != null && item.Id > 0)
                    {
                        existingCart.Items.Add(item);
                    }

                    return existingCart;
                },
                new { Id = id },
                splitOn: "Id"
            );

            return cartDictionary.Values.FirstOrDefault();
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
