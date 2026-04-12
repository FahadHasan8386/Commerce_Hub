using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }                // Product ID for update
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Sku { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
