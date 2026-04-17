using MediatR;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public int OrderStatus { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string? PaymentMethod { get; set; }
        public List<UpdateOrderItemCommand> Items { get; set; } = new();
    }

    public class UpdateOrderItemCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
