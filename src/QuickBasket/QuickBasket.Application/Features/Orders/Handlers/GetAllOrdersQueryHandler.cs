using MediatR;
using QuickBasket.Application.Features.Orders.DTOs;
using QuickBasket.Application.Features.Orders.Queries;
using QuickBasket.Application.Interefaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Result<List<OrderResponseDto>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<List<OrderResponseDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();
            return Result<List<OrderResponseDto>>.Success(orders, 200);
        }
    }
}
