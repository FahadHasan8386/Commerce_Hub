using MediatR;
using QuickBasket.Application.Features.Orders.Commands;
using QuickBasket.Application.Features.Orders.DTOs;
using QuickBasket.Application.Interefaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new CreateOrderDto
            {
                UserId = request.UserId,
                OrderDate = request.OrderDate,
                TotalAmount = request.TotalAmount,
                OrderStatus = request.OrderStatus,
                ShippingAddress = request.ShippingAddress,
                PaymentMethod = request.PaymentMethod,
                CreatedAt = DateTime.UtcNow,
                Items = request.Items.Select(x => new CreateOrderItemDto
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    ProductName = x.ProductName
                }).ToList()
            };

            var orderId = await _orderRepository.CreateOrderAsync(order);
            return Result<int>.Success(orderId, 201);
        }
    }
}
