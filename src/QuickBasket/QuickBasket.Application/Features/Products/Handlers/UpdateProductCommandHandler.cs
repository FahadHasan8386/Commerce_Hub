using MediatR;
using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Products.Commands;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Interefaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<int>>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new UpdateProductDto
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                CategoryId = request.CategoryId
            };

            var productId = await _productRepository.UpdateProductAsync(product);
            return Result<int>.Success(productId, 200);

        }
    }
}
