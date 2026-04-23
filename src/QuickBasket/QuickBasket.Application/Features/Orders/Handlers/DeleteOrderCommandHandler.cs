using MediatR;
using QuickBasket.Application.Features.Orders.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result<bool>>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<bool>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                return Result<bool>.Failure("Order not found", 404);
            }

            await _orderRepository.DeleteOrderAsync(request.Id);
            return Result<bool>.Success(true, 200);
        }
    }
}
