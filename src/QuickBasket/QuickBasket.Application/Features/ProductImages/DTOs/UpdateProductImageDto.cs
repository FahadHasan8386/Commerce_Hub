using QuickBasket.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImages.DTOs
{
    public class UpdateProductImageDto : BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }

    }
}
