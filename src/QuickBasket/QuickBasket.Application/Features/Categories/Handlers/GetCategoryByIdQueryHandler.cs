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
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
         
        public async Task<Result<CategoryResponseDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if(category == null)
            {
                return Result<CategoryResponseDto>.Failure($"Category with Id {request.Id} not found", 404);
            }
            return Result<CategoryResponseDto>.Success(category, 200);
        }
    }
}
