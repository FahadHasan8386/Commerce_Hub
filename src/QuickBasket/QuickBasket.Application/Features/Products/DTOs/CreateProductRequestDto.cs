using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Products.DTOs
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Sku { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
