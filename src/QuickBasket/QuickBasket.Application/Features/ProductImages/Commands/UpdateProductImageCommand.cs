using MediatR;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.ProductImages.Commands
{
    public class UpdateProductImageCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }

    }
}
