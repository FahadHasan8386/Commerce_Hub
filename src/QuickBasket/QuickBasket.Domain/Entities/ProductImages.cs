using QuickBasket.Domain.BaseModel;

namespace QuickBasket.Domain.Entities
{
    public class ProductImages : BaseEntity
    {
        public string? ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int ProductId { get; set; }
    }
}
