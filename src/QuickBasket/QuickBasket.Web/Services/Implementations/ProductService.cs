using QuickBasket.Web.Models;
using QuickBasket.Web.Services.Interfaces;

namespace QuickBasket.Web.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpclient;

        public ProductService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }

        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            var response = await _httpclient.GetAsync("products");

            if (!response.IsSuccessStatusCode)
                return new List<ProductViewModel>();

            return await response.Content.ReadFromJsonAsync<List<ProductViewModel>>();
        }

    }
}
