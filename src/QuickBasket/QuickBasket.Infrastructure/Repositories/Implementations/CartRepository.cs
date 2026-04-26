using Dapper;
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
            const string sql = @"SELECT Id, UserId, SessionId, IsCheckedOut
                             FROM Carts
                             WHERE IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<CartResponseDto>(sql)).ToList();
        }

        public async Task<CartResponseDto?> GetByIdAsync(int id)
        {
            const string sql = @"SELECT Id, UserId, SessionId, IsCheckedOut
                             FROM Carts
                             WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<CartResponseDto>(sql, new { Id = id });
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
