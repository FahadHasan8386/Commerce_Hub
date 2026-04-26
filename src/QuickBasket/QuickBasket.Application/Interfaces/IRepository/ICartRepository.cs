using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Application.Features.Carts.DTOs;
using QuickBasket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interfaces.IRepository
{
    public interface ICartRepository
    {
        Task<List<CartResponseDto>> GetAllAsync();
        Task<CartResponseDto?> GetByIdAsync(int id);
        Task<int> CreateCartAsync(Cart cart);
        Task<int> UpdateCartAsync(Cart cart);
        Task<bool> DeleteCartAsync(int id);
    }
}
