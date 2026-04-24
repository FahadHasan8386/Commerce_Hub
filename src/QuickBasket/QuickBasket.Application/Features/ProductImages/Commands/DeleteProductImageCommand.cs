using MediatR;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.ProductImages.Commands
{
    public class DeleteProductImageCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public DeleteProductImageCommand(int id)
        {
            Id = id;
        }
    }
}
