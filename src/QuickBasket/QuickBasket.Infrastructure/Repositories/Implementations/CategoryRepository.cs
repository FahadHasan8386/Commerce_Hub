using Dapper;
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

        public async Task<int> CreateCategoryAsync(Category category)
        {
            const string sql = @"INSERT INTO Categories (Name, Description)
                                VALUES (@Name, @Description);
                                SELECT CAST(SCOPE_IDENTITY() as int)";

            using var connection = _context.CreateConnection();
            var id = await connection.ExecuteAsync(sql, category);
            return id;
        }
    }
}
