using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interfaces.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task<CategoryResponseDto?> GetByIdAsync(int id);
        Task<int> CreateCategoryAsync(Category category);
        Task<int> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
