using System.ComponentModel.DataAnnotations;

namespace QuickBasket.Application.Features.Categories.DTOs
{
    public class CreateCategoryDto 
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
