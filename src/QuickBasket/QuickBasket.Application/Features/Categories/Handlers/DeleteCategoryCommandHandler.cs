using MediatR;
using QuickBasket.Application.Features.Categories.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Categories.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<bool>>  
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)  
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<bool>> Handle(DeleteCategoryCommand request , CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if(category == null)
            {
                return Result<bool>.Failure("Category Not Found", 404);
            }

            await _categoryRepository.DeleteCategoryAsync(request.Id);
            return Result<bool>.Success(true, 200);
        }
    }
}
