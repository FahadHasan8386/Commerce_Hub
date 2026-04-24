using QuickBasket.Domain.BaseModel;

namespace QuickBasket.Domain.Entities
{
    public class CartItems : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    } 
}
