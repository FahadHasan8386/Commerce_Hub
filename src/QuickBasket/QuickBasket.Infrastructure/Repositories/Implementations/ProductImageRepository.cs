using Dapper;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Features.ProductImage.DTOs;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Interfaces;
using QuickBasket.Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Infrastructure.Repositories.Implementations
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly IDapperContext _context;

        public ProductImageRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<ProductImageDto>> GetAllAsync()
        {
            const string sql = @"SELECT * FROM ProductImages";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<ProductImageDto>(sql)).ToList();
        }

        public async Task<ProductImageDto> GetByIdAsync(int id)
        {
            const string sql = @"SELECT Id ,ProductId , ImageUrl ,IsPrimary , CreatedAt FROM ProductImages 
                                 WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ProductImageDto>(sql, new { Id = id });
        }

        public async Task<int> CreateProductImageAsync(CreateProductImageDto productImage)
        {
            const string sql = @"INSERT INTO ProductImages 
                                (ProductId, ImageUrl, IsPrimary, CreatedAt)
                                VALUES 
                                (@ProductId, @ImageUrl, @IsPrimary, @CreatedAt);
                                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = _context.CreateConnection();
            var id = await connection.ExecuteAsync(sql, productImage);
            return id;
        }

        public async Task<int> UpdateProductImageAsync(ProductImageDto productImage)
        {
            const string sql = @"UPDATE ProductImages SET
                                ProductId = @ProductId,
                                ImageUrl = @ImageUrl,
                                IsPrimary = @IsPrimary
                                WHERE Id = @Id;";

            using var connection = _context.CreateConnection();
            var rowAffected = await connection.ExecuteAsync(sql, productImage);
            return rowAffected;
        }

        public async Task<bool> DeleteProductImageAsync(int id)
        {
            const string sql = @"DELETE FROM ProductImages WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            var rowAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowAffected > 0;
        }

        public Task<int> UpdateProductImageAsync(UpdateProductImageDto productImage)
        {
            throw new NotImplementedException();
        }
    }
}
