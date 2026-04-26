using QuickBasket.Domain.BaseModel;

namespace QuickBasket.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public string? ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int ProductId { get; set; }
    }
}
