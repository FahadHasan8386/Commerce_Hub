using QuickBasket.Application.Features.CartItems.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.DTOs
{
    public class CartResponseDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? SessionId { get; set; }
        public bool IsCheckedOut { get; set; }

        public List<CartItemResponseDto> Items { get; set; } = [];
    }
}
