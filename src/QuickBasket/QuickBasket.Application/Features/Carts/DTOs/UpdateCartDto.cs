using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.DTOs
{
    public class UpdateCartDto
    {
        public int Id { get; set; }
        public bool? IsCheckedOut { get; set; }
    }
}
