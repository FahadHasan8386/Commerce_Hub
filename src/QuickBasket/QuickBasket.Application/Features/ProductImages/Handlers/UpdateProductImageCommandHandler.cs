using MediatR;
using QuickBasket.Application.Features.Categories.Commands;
using QuickBasket.Application.Features.ProductImage.Commands;
using QuickBasket.Application.Features.ProductImage.DTOs;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.Handlers
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, Result<int>>
    {
        public readonly IProductImageRepository _productImageRepository;

        public UpdateProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<Result<int>> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = new UpdateProductImageDto
            {
                Id  = request.Id,
                ProductId = request.ProductId,
                ImageUrl = request.ImageUrl,
                IsPrimary = request.IsPrimary
            };
            var productImageId = await _productImageRepository.UpdateProductImageAsync(productImage);
            return Result<int>.Success(productImageId, 201);
        }
    } 
}
