using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.Commands
{
    public class UpdateProductImageCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public bool? IsPrimary { get; set; }

    }
}
