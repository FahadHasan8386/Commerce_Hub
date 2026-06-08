using System.Net.Http.Json;
using QuickBasket.Application.Features.CartItems.DTOs;

namespace QuickBasket.Web.Services
{
    public class CartApiService
    {
        private readonly HttpClient _httpClient;

        public CartApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CartItemResponseDto>> GetAllCartItemsAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<CartItemResponseDto>>
                ("api/cartitems")
                ?? new List<CartItemResponseDto>();
        }

        public async Task<CartItemResponseDto?> GetCartItemByIdAsync(int id)
        {
            return await _httpClient
                .GetFromJsonAsync<CartItemResponseDto>
                ($"api/cartitems/{id}");
        }

        public async Task<List<CartItemResponseDto>> GetCartItemsByCartIdAsync(int cartId)
        {
            return await _httpClient
                .GetFromJsonAsync<List<CartItemResponseDto>>
                ($"api/carts/{cartId}/items")
                ?? new List<CartItemResponseDto>();
        }

        public async Task<bool> AddToCartAsync(CreateCartItemDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/cartitems",
                dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCartItemAsync(UpdateCartItemDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/cartitems/{dto.Id}",
                dto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCartItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/cartitems/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}