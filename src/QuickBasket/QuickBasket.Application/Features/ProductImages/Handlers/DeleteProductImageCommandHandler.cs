using MediatR;
using QuickBasket.Application.Features.ProductImage.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.Handlers
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand , Result<bool>>
    {
        private readonly IProductImageRepository _productImageRepository;

        public DeleteProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<Result<bool>> Handle(DeleteProductImageCommand  request , CancellationToken cancellationToken)
        {
            var productImage = await _productImageRepository.GetByIdAsync(request.Id);

            if(productImage == null)
            {
                return Result<bool>.Failure("Image not found.", 404);
            }
            return Result<bool>.Success(true, 200);
        }
    }
}
  