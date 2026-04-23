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
            const string sql = @"SELECT Id , Name ,Description FROM Categories 
                                 WHERE IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return(await connection.QueryAsync<CategoryResponseDto>(sql)).ToList();
        }

        public async Task<CategoryResponseDto?> GetByIdAsync(int id)
        {
            const string sql = @"SELECT Id, Name, Description 
                                 FROM Categories 
                                 WHERE Id = @Id AND IsDeleted = 0";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<CategoryResponseDto>(sql, new { Id = id });
        }

        public async Task<int> CreateCategoryAsync(Category category)
        {
            const string sql = @"INSERT INTO Categories 
                                (Name, Description, CreatedAt, CreatedBy, IsDeleted)
                                VALUES
                                (@Name, @Description, @CreatedAt, @CreatedBy, @IsDeleted);
                        
                                SELECT CAST(SCOPE_IDENTITY() as int);";


            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, category);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            const string sql = @"UPDATE Categories SET
                                 Name = COALESCE(@Name, Name),
                                 Description = COALESCE(@Description, Description),
                                 ModifiedAt = @ModifiedAt,
                                 ModifiedBy = @ModifiedBy
                               WHERE Id = @Id AND IsDeleted = 0;";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, category);
            
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            const string sql = @"UPDATE Categories SET
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
 