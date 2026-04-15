using QuickBasket.Domain.BaseModel;

namespace QuickBasket.API.Models.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string UserId   { get; set; }
        public DateTime OderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OderStatus { get; set; }
        public string ShippingAddress { get; set; }

    }
}
