using QuickBasket.Application.Features.ProductImages.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Products.DTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }

        public List<ProductImageResponseDto> Images { get; set; } = new();
    }
}
