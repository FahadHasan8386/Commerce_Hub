using MediatR;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Features.ProductImages.Queries;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.ProductImages.Handlers
{
    public class GetProductImageQueryHandler : IRequestHandler<GetProductImagesQuery, Result<List<ProductImageResponseDto>>>
    {
        private readonly IProductImageRepository _repository;

        public GetProductImageQueryHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ProductImageResponseDto>>> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
        {
            var images = await _repository.GetAllAsync();
            if(images == null)
            {
                return Result<List<ProductImageResponseDto>>.Failure("Not found", 404);
            }
            return Result<List<ProductImageResponseDto>>.Success(images, 200);
        }
    }
}
  