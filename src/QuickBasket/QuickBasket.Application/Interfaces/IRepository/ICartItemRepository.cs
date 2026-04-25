using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interfaces.IRepository
{
    public interface ICartItemRepository
    {
        Task<List<CartItemResponseDto>> GetAllAsync();
        Task<CartItemResponseDto?> GetByIdAsync(int id);
        Task<int> CreateCartItemAsync(CartItems cartItems);
        Task<int> UpdateCartItemAsync(CartItems cartItems);
        Task<bool> DeleteCartItemAsync(int id);
    }
}
