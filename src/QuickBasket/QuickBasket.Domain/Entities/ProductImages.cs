using QuickBasket.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Domain.Entities
{
    public class ProductImages : BaseEntity
    {
        public long ProductId { get; set; }

        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }

    }
}
