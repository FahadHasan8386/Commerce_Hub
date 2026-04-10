using AutoMapper;
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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery , Result <ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.Id);
            }
            var productDto = _mapper.Map<ProductDto>(product);

            return Result<ProductDto>.Success(productDto);
        }
    }
}
