namespace QuickBasket.Web.Services
{
    using QuickBasket.Application.Features.Products.DTOs;
    using QuickBasket.Shared.Helpers;
    using System.Net.Http.Json;

    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ProductResponseDto>>("api/Products");
                return response ?? new List<ProductResponseDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return new List<ProductResponseDto>();
            }
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ProductResponseDto>($"api/Products/{id}");

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product by id: {ex.Message}");
                return null;
            }
        }
    }
}
