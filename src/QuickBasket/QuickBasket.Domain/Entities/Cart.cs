using QuickBasket.Domain.BaseModel;

namespace QuickBasket.API.Models.Entities
{
    public class Cart : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }

    }
}
