using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interefaces.IRepository
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<int> CreateProductAsync(CreateProductDto product);
        Task<int> UpdateProductAsync(UpdateProductDto product);
        Task<bool> DeleteProductAsync(int id);
    }
}
