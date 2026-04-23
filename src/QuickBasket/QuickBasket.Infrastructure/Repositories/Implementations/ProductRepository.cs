using QuickBasket.API.Models.Entities;
using QuickBasket.Infrastructure.Data;
using System;
using System.Collections.Generic;
using Dapper;
using System.Text;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Application.Interfaces;
using QuickBasket.Application.Features.Products.DTOs;

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
            const string sql = @"SELECT Id,Name,Description,Price,StockQuantity,CategoryId
                          FROM Products
                          WHERE IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<ProductResponseDto>(sql)).ToList();
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            const string sql = @"SELECT Id,Name,Description,Price,StockQuantity,CategoryId
                          FROM Products
                          WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ProductResponseDto>(sql, new { Id = id });
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
