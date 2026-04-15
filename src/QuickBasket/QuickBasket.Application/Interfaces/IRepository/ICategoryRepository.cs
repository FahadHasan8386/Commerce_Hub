using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Interfaces.IRepository
{
    public interface ICategoryRepository
    {
        Task<int> CreateCategoryAsync(Category category);
    }
}
