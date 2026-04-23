using MediatR;
using QuickBasket.Application.Features.ProductImage.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.ProductImage.Handlers
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand , Result<int>>
    {
        public readonly IProductImageRepository _productImageRepository;

        public CreateProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<Result<int>> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = new ProductImage
            {
                ProductId = request.ProductId,
                ImageUrl = request.ImageUrl,
                IsPrimary = request.IsPrimary,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System",
                IsDeleted = false
            };

            var productImageId = await _productImageRepository.CreateProductImageAsync(productImage);
            return Result<int>.Success(productImageId, 201);
        }
    }
}
