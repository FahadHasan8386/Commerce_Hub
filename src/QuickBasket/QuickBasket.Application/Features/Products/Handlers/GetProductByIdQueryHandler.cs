using MediatR;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Features.Products.Queries;
using QuickBasket.Application.Interefaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductResponseDto>>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProductResponseDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productEntity = await _repository.GetByIdAsync(request.Id);

            if (productEntity == null)
            {
                return Result<ProductResponseDto>.Failure($"Product with Id {request.Id} not found");
            }
            var dto = new ProductResponseDto
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Description = productEntity.Description,
                Price = productEntity.Price,
                StockQuantity = productEntity.StockQuantity,
                CategoryId = productEntity.CategoryId
            };
            return Result<ProductResponseDto>.Success(dto);
        }
    }
}