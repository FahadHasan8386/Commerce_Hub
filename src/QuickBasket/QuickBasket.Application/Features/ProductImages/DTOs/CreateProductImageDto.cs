using QuickBasket.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.DTOs
{
    public class CreateProductImageDto
    {
        public string? ImageUrl { get; set; } = string.Empty;
        public bool? IsPrimary { get; set; }
        public int? ProductId { get; set; }
    }
}
