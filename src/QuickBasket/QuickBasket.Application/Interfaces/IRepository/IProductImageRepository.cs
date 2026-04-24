using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interfaces.IRepository
{
    public interface IProductImageRepository
    {
        Task<List<ProductImageResponseDto>> GetAllAsync();
        Task<ProductImageResponseDto?> GetByIdAsync(int id);
        Task<int> CreateProductImageAsync(ProductImages productImage);
        Task<int> UpdateProductImageAsync(ProductImages productImage);
        Task<bool> DeleteProductImageAsync(int id);
    }
}
