using QuickBasket.Domain.BaseModel;

namespace QuickBasket.API.Models.Entities
{
    public class Carts : BaseEntity
    {
        public int Id { get; set; }

        public int? UserId { get; set; }    
        public string? SessionId { get; set; } 

        public bool IsCheckedOut { get; set; } = false;

    }
}
