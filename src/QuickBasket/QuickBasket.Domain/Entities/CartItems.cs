using QuickBasket.Domain.BaseModel;

namespace QuickBasket.API.Models.Entities
{
    public class CartItems : BaseEntity
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId  { get; set; }
        public int Quantity { get; set; }

    }
}
