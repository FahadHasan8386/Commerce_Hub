using MediatR;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.ProductImages.Queries
{
    public class GetProductImageByIdQuery : IRequest<Result<ProductImageResponseDto>>
    {
        public int Id { get; set; }

        public GetProductImageByIdQuery(int id)
        {
            Id = id;
        }
    }
}
