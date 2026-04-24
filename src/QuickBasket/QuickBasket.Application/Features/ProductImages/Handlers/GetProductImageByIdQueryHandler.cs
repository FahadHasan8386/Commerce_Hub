using MediatR;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Features.ProductImages.Queries;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.ProductImages.Handlers
{
    public class GetProductImageByIdQueryHandler : IRequestHandler<GetProductImageByIdQuery , Result<ProductImageResponseDto>>
    {
        private readonly IProductImageRepository _productImageRepository;

        public GetProductImageByIdQueryHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public async Task<Result<ProductImageResponseDto>> Handle(GetProductImageByIdQuery request, CancellationToken cancellationToken)
        {
            var productImage = await _productImageRepository.GetByIdAsync(request.Id);

            if(productImage == null)
            {
                return Result<ProductImageResponseDto>.Failure($"Image with Id {request.Id} not found", 404);
            }
            return Result<ProductImageResponseDto>.Success(productImage, 200);
        }
    }
}
 