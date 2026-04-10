using QuickBasket.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interefaces.IRepository
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<int> CreateAsync(Product product);
    }
}
