using QuickBasket.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interefaces.IRepository
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<int> CreateProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
    }
}
