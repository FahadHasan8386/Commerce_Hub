using MediatR;
using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Features.Products.Queries;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Products.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<List<ProductResponseDto>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<ProductResponseDto>>> Handle(GetAllProductsQuery request,CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAllAsync();

            if(product == null || !product.Any())
            {
                return Result<List<ProductResponseDto>>.Failure("Product not found ", 404);
            }

            return Result<List<ProductResponseDto>>.Success(product, 200);
        }
    }
}
