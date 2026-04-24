namespace QuickBasket.Application.Features.ProductImages.DTOs
{
    public class UpdateProductImageDto 
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public int ProductId { get; set; }
    }
}
