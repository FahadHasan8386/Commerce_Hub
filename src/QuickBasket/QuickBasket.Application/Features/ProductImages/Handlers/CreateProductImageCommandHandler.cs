using MediatR;
using QuickBasket.Application.Features.ProductImage.Commands;
using QuickBasket.Application.Features.ProductImage.DTOs;
using QuickBasket.Application.Interefaces.IRepository;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.Handlers
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand , Result<int>>
    {
        public readonly IProductImageRepository _productImageRepository;

        public CreateProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<Result<int>> Handle(CreateProductImageCommand request , CancellationToken cancellationToken)
        {
            var productImage = new CreateProductImageDto
            {
                ProductId = request.ProductId,
                ImageUrl = request.ImageUrl,
                IsPrimary = request.IsPrimary
            };
            var productImageId = await _productImageRepository.CreateProductImageAsync(productImage);
            return Result<int>.Success(productImageId, 201);
        }
    }
}
