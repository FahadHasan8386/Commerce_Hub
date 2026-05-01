using QuickBasket.Web.Models;

namespace QuickBasket.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();
    }
}
