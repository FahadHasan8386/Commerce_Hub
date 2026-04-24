using MediatR;
using QuickBasket.Application.Features.ProductImages.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using QuickBasket.Domain.Entities; 

namespace QuickBasket.Application.Features.ProductImages.Handlers
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, Result<int>>
    {
        private readonly IProductImageRepository _productImageRepository;

        public UpdateProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<Result<int>> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = new ProductImages
            {
                Id = request.Id,
                ProductId = request.ProductId,
                ImageUrl = request.ImageUrl,
                IsPrimary = request.IsPrimary,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = "System"
            };

            var result = await _productImageRepository.UpdateProductImageAsync(productImage);
            return Result<int>.Success(result, 200);
        }
    }
}