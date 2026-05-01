using Microsoft.AspNetCore.Mvc;
using QuickBasket.Web.Services.Implementations;
using QuickBasket.Web.Services.Interfaces;

namespace QuickBasket.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }
    }
}
