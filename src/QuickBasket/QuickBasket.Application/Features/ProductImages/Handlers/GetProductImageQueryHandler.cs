using MediatR;
using QuickBasket.Application.Features.ProductImage.DTOs;
using QuickBasket.Application.Features.ProductImage.Queries;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.Handlers
{
    public class GetProductImageQueryHandler : IRequestHandler<GetProductImagesQuery, Result<List<ProductImageDto>>>
    {
        private readonly IProductImageRepository _repository;

        public GetProductImageQueryHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ProductImageDto>>> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
        {
            var images = await _repository.GetAllAsync();
            if(images == null)
            {
                return Result<List<ProductImageDto>>.Failure("Not found", 404);
            }
            return Result<List<ProductImageDto>>.Success(images, 200);
        }
    }
}
  