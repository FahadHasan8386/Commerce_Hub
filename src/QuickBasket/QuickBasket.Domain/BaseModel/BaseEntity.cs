using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Domain.BaseModel
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; } = "Fahad";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool InActive { get; set; } = false;

        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
