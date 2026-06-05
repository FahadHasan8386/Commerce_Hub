using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.DTOs
{
    public class CartItemResponseDto
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string? ProductImageUrl { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
