using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.DTOs
{
    public class CreateCartItemDto
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}
