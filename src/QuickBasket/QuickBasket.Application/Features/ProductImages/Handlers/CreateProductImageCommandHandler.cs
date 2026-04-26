using MediatR;
using QuickBasket.Application.Features.ProductImages.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using QuickBasket.Domain.Entities;

namespace QuickBasket.Application.Features.ProductImages.Handlers
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, Result<int>>
    {
        private readonly IProductImageRepository _productImageRepository;

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

            var id = await _productImageRepository.CreateProductImageAsync(productImage);
            return Result<int>.Success(id, 201);
        }
    }

}