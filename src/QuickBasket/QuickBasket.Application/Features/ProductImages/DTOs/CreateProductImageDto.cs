using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.DTOs
{
    public class CreateProductImageDto
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }

    }
}
