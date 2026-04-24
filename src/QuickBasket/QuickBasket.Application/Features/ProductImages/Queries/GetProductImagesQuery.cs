using MediatR;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.ProductImages.Queries
{
    public class GetProductImagesQuery : IRequest<Result<List<ProductImageResponseDto>>>
    {
    }
}
