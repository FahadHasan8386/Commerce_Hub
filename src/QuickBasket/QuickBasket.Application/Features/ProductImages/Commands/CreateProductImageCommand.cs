using MediatR;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.ProductImages.Commands
{
    public class CreateProductImageCommand : IRequest<Result<int>>
    {
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public int ProductId { get; set; }

    }
}
