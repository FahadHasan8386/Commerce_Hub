using MediatR;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Features.Products.Queries;
using QuickBasket.Application.Interefaces.IRepository;
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
            var products = await _productRepository.GetAllAsync();

            var dtos = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                StockQuantity = p.StockQuantity,
                CategoryId = p.CategoryId
            }).ToList();

            return Result<List<ProductResponseDto>>.Success(dtos, 200);
        }
    }
}
