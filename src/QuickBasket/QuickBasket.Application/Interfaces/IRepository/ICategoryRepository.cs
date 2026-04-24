using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Domain.Entities;
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
