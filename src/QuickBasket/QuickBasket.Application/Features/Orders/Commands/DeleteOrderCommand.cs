using MediatR;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Commands
{
    public class DeleteOrderCommand : IRequest<Result<bool>>
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
