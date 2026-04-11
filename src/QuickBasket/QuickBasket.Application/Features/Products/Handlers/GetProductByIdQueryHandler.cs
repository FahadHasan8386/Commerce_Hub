using MediatR;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Features.Products.Queries;
using QuickBasket.Application.Interefaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productEntity = await _repository.GetByIdAsync(request.Id);

            if (productEntity == null)
            {
                return Result<ProductDto>.Failure($"Product with Id {request.Id} not found");
            }
            var dto = new ProductDto
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Price = productEntity.Price
            };

            return Result<ProductDto>.Success(dto);
        }
    }
}