using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Application.Features.Carts.DTOs;
using System.Net.Http.Json;

namespace QuickBasket.Web.Services
{
    public class CartApiService
    {
        private readonly HttpClient _httpClient;

        public CartApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CartResponseDto>> GetAllCartsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CartResponseDto>>
           ("api/Carts") ?? new();
        }
        public async Task<List<CartItemResponseDto>> GetCartItemsAsync(int cartId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<CartItemResponseDto>>
                ($"api/carts/{cartId}/items");

            return result ?? new List<CartItemResponseDto>();
        }
    }
}
