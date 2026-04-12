using MediatR;
using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Products.Commands;
using QuickBasket.Application.Interefaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<int>> Handle(CreateProductCommand request , CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                Sku = request.Sku,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.UtcNow
            };

            var productId = await _productRepository.CreateProductAsync(product);
            return Result<int>.Success(productId, 201);
        }
    }
}
