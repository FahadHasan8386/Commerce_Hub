using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace QuickBasket.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
