using MediatR;
using QuickBasket.Domain.Entities;
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
            var category = new Category
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                //Audit Fields(Server sidee)
                ModifiedAt = DateTime.Now,
                ModifiedBy = "System"
            };
            var categoryId = await _categoryRepository.UpdateCategoryAsync(category);

            if(categoryId ==  0)
            {
                return Result<int>.Failure("Update Failed", 400);
            }
            return Result<int>.Success(categoryId, 200);
        }
    }
}
