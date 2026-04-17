using MediatR;
using QuickBasket.Application.Features.Orders.DTOs;
using QuickBasket.Application.Features.Orders.Queries;
using QuickBasket.Application.Interefaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderResponseDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<OrderResponseDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                return Result<OrderResponseDto>.Failure($"Order with Id {request.Id} not found", 404);
            }

            return Result<OrderResponseDto>.Success(order, 200);
        }
    }
}
