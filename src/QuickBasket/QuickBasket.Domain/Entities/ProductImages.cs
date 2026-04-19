using QuickBasket.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Domain.Entities
{
    public class ProductImages
    {
        public long Id { get; set; }
        public long ProductId { get; set; }

        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
