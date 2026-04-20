using MediatR;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Features.Categories.Queries;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Categories.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery , Result<List<CategoryResponseDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task <Result<List<CategoryResponseDto>>> Handle(GetAllCategoryQuery request , CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAllAsync();
            if(category == null)
            {
                return Result<List<CategoryResponseDto>>.Failure("Category not found", 404);
            }
            return Result<List<CategoryResponseDto>>.Success(category, 200);
        }
    }
}
   