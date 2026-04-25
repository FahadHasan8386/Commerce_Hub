using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Commands
{
    public class UpdateCartItemCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}
