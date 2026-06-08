using Dapper;
using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Application.Interfaces;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Domain.Entities;

namespace QuickBasket.Infrastructure.Repositories.Implementations
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly IDapperContext _context;

        public CartItemRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<CartItemResponseDto>> GetAllAsync()
        {
            const string sql = @"
                                SELECT
                                    ci.Id,
                                    ci.CartId,
                                    ci.ProductId,
                                    ci.Quantity,
                                    ci.UnitPrice,

                                    p.Name AS ProductName,

                                    c.Name AS CategoryName,

                                    pi.ImageUrl AS ProductImageUrl

                                FROM CartItems ci

                                INNER JOIN Products p
                                    ON ci.ProductId = p.Id

                                LEFT JOIN Categories c
                                    ON p.CategoryId = c.Id

                                LEFT JOIN ProductImages pi
                                    ON p.Id = pi.ProductId
                                    AND pi.IsPrimary = 1

                                WHERE ci.IsDeleted = 0";

            using var connection = _context.CreateConnection();

            return (await connection.QueryAsync<CartItemResponseDto>(sql))
                .ToList();
        }

        public async Task<CartItemResponseDto?> GetByIdAsync(int id)
        {
            const string sql = @"
                                SELECT
                                    ci.Id,
                                    ci.CartId,
                                    ci.ProductId,
                                    ci.Quantity,
                                    ci.UnitPrice,

                                    p.Name AS ProductName,

                                    c.Name AS CategoryName,

                                    pi.ImageUrl AS ProductImageUrl

                                FROM CartItems ci

                                INNER JOIN Products p
                                    ON ci.ProductId = p.Id

                                LEFT JOIN Categories c
                                    ON p.CategoryId = c.Id

                                LEFT JOIN ProductImages pi
                                    ON p.Id = pi.ProductId
                                    AND pi.IsPrimary = 1

                                WHERE ci.Id = @Id
                                  AND ci.IsDeleted = 0";

            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<CartItemResponseDto>(
                sql,
                new { Id = id });
        }

        public async Task<int> CreateCartItemAsync(CartItem cartItem)
        {
            const string sql = @"INSERT INTO CartItems 
                                ( Quantity, UnitPrice, CartId, ProductId, CreatedAt , CreatedBy ,IsDeleted)
                                VALUES 
                                ( @Quantity, @UnitPrice, @CartId, @ProductId, @CreatedAt , @CreatedBy ,@IsDeleted);
                                SELECT CAST(SCOPE_IDENTITY() as int)";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, cartItem);
        }

        public async Task<int> UpdateCartItemAsync(CartItem cartItem)
        {
            const string sql = @"UPDATE CartItems SET
                                Quantity = COALESCE(@Quantity, Quantity),
                                UnitPrice = COALESCE(@UnitPrice, UnitPrice),
                                CartId = COALESCE(@CartId, CartId),
                                ProductId = COALESCE(@ProductId, ProductId),
                                ModifiedAt = @ModifiedAt,
                                 ModifiedBy = @ModifiedBy
                               WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, cartItem);
        }

        public async Task<bool> DeleteCartItemAsync(int id)
        {
            const string sql = @"UPDATE CartItems SET
                                 IsDeleted = 1,
                                 ModifiedAt = @ModifiedAt,
                                 ModifiedBy = @ModifiedBy
                               WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync(sql, new
            {
                Id = id,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = "System"
            });

            return rowsAffected > 0;
        }
    }
}
  