using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.DTOs
{
    public class CreateCartDto
    {
        public int? UserId { get; set; }
        public string? SessionId { get; set; }
    }
}
