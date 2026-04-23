using MediatR;
using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Categories.Commands;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Categories.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand , Result<int>>
    {
        public readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<int>> Handle(CreateCategoryCommand request , CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System",
                IsDeleted = false
            };
            var categoryId = await _categoryRepository.CreateCategoryAsync(category);
            return Result<int>.Success(categoryId, 201);
        }        
    }
}
