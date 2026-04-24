using QuickBasket.Domain.BaseModel;

namespace QuickBasket.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int? UserId { get; set; }    
        public string? SessionId { get; set; } 
        public bool IsCheckedOut { get; set; } = false;

    }
}
