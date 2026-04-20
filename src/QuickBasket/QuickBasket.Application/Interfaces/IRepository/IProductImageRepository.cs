using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Features.ProductImage.DTOs;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interfaces.IRepository
{
    public interface IProductImageRepository
    {
        Task<List<ProductImageDto>> GetAllAsync();
        Task<ProductImageDto?> GetByIdAsync(int id);
        Task<int> CreateProductImageAsync(CreateProductImageDto productImage);
        Task<int> UpdateProductImageAsync(UpdateProductImageDto productImage);
        Task<bool> DeleteProductImageAsync(int id);
    }
}
