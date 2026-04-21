using Dapper;
using Microsoft.IdentityModel.Tokens.Experimental;
using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Interfaces;
using QuickBasket.Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Infrastructure.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDapperContext _context;
        public CategoryRepository(IDapperContext context)
        {
            _context = context; 
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            const string sql = @"SELECT * FROM Categories";

            using var connection = _context.CreateConnection();
            return(await connection.QueryAsync<CategoryResponseDto>(sql)).ToList();
        }

        public async Task<CategoryResponseDto> GetByIdAsync(int id)
        {
            const string sql = @"SELECT Id , Name ,Description FROM Categories 
                                 WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<CategoryResponseDto>(sql, new { Id = id });
        }

        public async Task<int> CreateCategoryAsync(CreateCategoryDto category)
        {
            const string sql = @"INSERT INTO Categories (Name, Description )
                                VALUES (@Name, @Description );
                                SELECT CAST(SCOPE_IDENTITY() as int)";

            using var connection = _context.CreateConnection();
            var id = await connection.ExecuteAsync(sql, category);
            return id;
        }

        public async Task<int> UpdateCategoryAsync(UpdateCategoryDto category)
        {
            const string sql = @"UPDATE Categories SET
                                 Name = @Name,
                                 Description = @Description
                               WHERE Id = @Id;";

            using var connection = _context.CreateConnection();
            var rawAffected = await connection.ExecuteAsync(sql, category);
            return rawAffected;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            const string sql = @"DELETE FROM Categories WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            var rowAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowAffected > 0;
        }
    }
}
 