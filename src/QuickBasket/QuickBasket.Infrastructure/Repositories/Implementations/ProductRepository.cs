using Dapper;
using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Interfaces;
using QuickBasket.Application.Interfaces.IRepository;

namespace QuickBasket.Infrastructure.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDapperContext _context;


        public ProductRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            const string productSql = @"SELECT Id,Name,Description,Price,StockQuantity,
                                        CategoryId FROM Products
                                              WHERE IsDeleted = 0";

            const string imageSql = @"SELECT Id,ImageUrl, IsPrimary,
                    ProductId FROM ProductImages";

            using var connection = _context.CreateConnection();

            var products = (await connection.QueryAsync<ProductResponseDto>(productSql)).ToList();

            var images = (await connection.QueryAsync<ProductImageResponseDto>(imageSql)).ToList();

            foreach (var product in products)
            {
                product.Images = images.Where(i => i.ProductId == product.Id)
                    .ToList();
            }
            return products;
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            const string productSql = @"SELECT Id, Name, Description, Price,StockQuantity,
                                        CategoryId FROM Products
                                            WHERE Id = @Id
                                            AND IsDeleted = 0";

            const string imageSql = @"SELECT Id,ImageUrl,IsPrimary,ProductId
                                    FROM ProductImages
                                    WHERE ProductId = @Id";

            using var connection = _context.CreateConnection();

            var product = await connection.QueryFirstOrDefaultAsync<ProductResponseDto>
                        (productSql,new { Id = id });

            if (product == null)
            {
                return null;
            }

            var images = await connection.QueryAsync<ProductImageResponseDto>
                            (imageSql,new { Id = id });

            product.Images = images.ToList();

            return product;
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            const string sql = @"INSERT INTO Products 
                                (Name, Description, Price, StockQuantity, CategoryId, CreatedAt , CreatedBy ,IsDeleted)
                                VALUES 
                                (@Name, @Description, @Price, @StockQuantity, @CategoryId, @CreatedAt , @CreatedBy ,@IsDeleted);
                                SELECT CAST(SCOPE_IDENTITY() as int)";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, product);
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            const string sql = @"UPDATE Products SET
                                Name = COALESCE(@Name, Name),
                                Description = COALESCE(@Description, Description),
                                Price = COALESCE(@Price, Price),
                                StockQuantity = COALESCE(@StockQuantity, StockQuantity),
                                CategoryId = COALESCE(@CategoryId, CategoryId),
                                ModifiedAt = @ModifiedAt,
                                 ModifiedBy = @ModifiedBy
                               WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, product);
            
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            const string sql = @"UPDATE Products SET
                                 IsDeleted = 1,
                                 ModifiedAt = @ModifiedAt,
                                 ModifiedBy = @ModifiedBy
                               WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync(sql, new 
            { 
                Id = id ,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = "System"
            });

            return rowsAffected > 0;
        }

      
    }
}
