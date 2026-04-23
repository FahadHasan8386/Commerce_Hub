using MediatR;
using QuickBasket.Application.Features.Orders.Commands;
using QuickBasket.Application.Features.Orders.DTOs;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<int>>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<int>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new UpdateOrderDto
            {
                Id = request.Id,
                UserId = request.UserId,
                OrderDate = request.OrderDate,
                TotalAmount = request.TotalAmount,
                OrderStatus = request.OrderStatus,
                ShippingAddress = request.ShippingAddress,
                PaymentMethod = request.PaymentMethod,
                Items = request.Items.Select(x => new UpdateOrderItemDto
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    ProductName = x.ProductName
                }).ToList()
            };

            var updatedRows = await _orderRepository.UpdateOrderAsync(order);
            if (updatedRows == 0)
            {
                return Result<int>.Failure("Order not found", 404);
            }

            return Result<int>.Success(updatedRows, 200);
        }
    }
}
