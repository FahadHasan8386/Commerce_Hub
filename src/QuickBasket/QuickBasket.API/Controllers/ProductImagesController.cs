using Microsoft.AspNetCore.Mvc;

namespace QuickBasket.API.Controllers
{
    public class ProductImagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
