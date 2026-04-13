using QuickBasket.API.Models.Entities;
using QuickBasket.Infrastructure.Data;
using System;
using System.Collections.Generic;
using Dapper;
using System.Text;
using QuickBasket.Application.Interefaces.IRepository;
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

        public async Task<Product?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Products WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Product>(sql, new {Id =  id}) ;
        }
        public async Task<int> CreateProductAsync(CreateProductDto product)
        {
            const string sql = @"
            INSERT INTO Products (Name, Description, Price, StockQuantity, Sku, CategoryId, CreatedAt)
            VALUES (@Name, @Description, @Price, @StockQuantity, @Sku, @CategoryId, @CreatedAt);
            SELECT CAST(SCOPE_IDENTITY() as int)";

            using var connection = _context.CreateConnection();
            var id = await connection.QuerySingleAsync<int>(sql, product);
            return id;
        }

        public async Task<int> UpdateProductAsync(UpdateProductDto product)
        {
            const string sql = @"UPDATE Products SET 
                                    Name = @Name,
                                    Description = @Description,
                                    Price = @Price,
                                    StockQuantity = @StockQuantity,
                                    Sku = @Sku,
                                    CategoryId = @CategoryId,
                                    UpdatedAt = @UpdatedAt
                                WHERE Id = @Id;";

            using var connection = _context.CreateConnection();
            var rowsAffected = await connection.ExecuteAsync(sql, product);
            return rowsAffected; 
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            const string sql = @"DELETE FROM Products WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });

            return rowsAffected > 0;
        }
    }
}
