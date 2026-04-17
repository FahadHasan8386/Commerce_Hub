using QuickBasket.Domain.BaseModel;

namespace QuickBasket.API.Models.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }   
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public int OrderStatus { get; set; }  // enum use 
        public string ShippingAddress { get; set; }
        public string? PaymentMethod { get; set; }

    }
}
