using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Domain.BaseModel
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public string CreatedBy { get; set; } = "System";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;

        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
