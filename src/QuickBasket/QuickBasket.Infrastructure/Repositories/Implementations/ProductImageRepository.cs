using Dapper;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Interfaces;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Domain.Entities;

namespace QuickBasket.Infrastructure.Repositories.Implementations
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly IDapperContext _context;

        public ProductImageRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<ProductImageResponseDto>> GetAllAsync()
        {
            const string sql = @"SELECT Id, ProductId, ImageUrl, IsPrimary, CreatedAt
                             FROM ProductImages
                             WHERE IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<ProductImageResponseDto>(sql)).ToList();
        }

        public async Task<ProductImageResponseDto?> GetByIdAsync(int id)
        {
            const string sql = @"SELECT Id, ProductId, ImageUrl, IsPrimary, CreatedAt
                             FROM ProductImages
                             WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ProductImageResponseDto>(sql, new { Id = id });
        }

        public async Task<int> CreateProductImageAsync(ProductImages productImage)
        {
            const string sql = @"INSERT INTO ProductImages 
                                (ProductId, ImageUrl, IsPrimary, CreatedAt, CreatedBy, IsDeleted)
                                VALUES 
                                (@ProductId, @ImageUrl, @IsPrimary, @CreatedAt, @CreatedBy, @IsDeleted);

                                SELECT CAST(SCOPE_IDENTITY() as int);";


            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, productImage);
         
        }

        public async Task<int> UpdateProductImageAsync(ProductImages productImage)
        {
            const string sql = @"UPDATE ProductImages SET 
                                ProductId = COALESCE(@ProductId, ProductId),
                                ImageUrl = COALESCE(@ImageUrl, ImageUrl),
                                IsPrimary = COALESCE(@IsPrimary, IsPrimary),
                                ModifiedAt = @ModifiedAt,
                                ModifiedBy = @ModifiedBy
                             WHERE Id = @Id AND IsDeleted = 0;";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, productImage); 
        }

        public async Task<bool> DeleteProductImageAsync(int id)
        {
            const string sql = @"UPDATE ProductImages SET
                                IsDeleted = 1,
                                ModifiedAt = @ModifiedAt,
                                ModifiedBy = @ModifiedBy
                             WHERE Id = @Id AND IsDeleted = 0";

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
