using MediatR;
using QuickBasket.Application.Features.Categories.Commands;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand ,Result<int>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task <Result<int>> Handle(UpdateCategoryCommand request , CancellationToken cancellationToken)
        {
            var category = new UpdateCategoryDto
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };
            var categoryId = await _categoryRepository.UpdateCategoryAsync(category);
            return Result<int>.Success(categoryId, 200);
        }
    }
}
