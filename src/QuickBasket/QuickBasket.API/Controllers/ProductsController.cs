using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBasket.Application.Features.Products.Queries;

namespace QuickBasket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await Mediator.Send(query);

            if(!result.IsSuccess)
            {
                return StatusCode(result.StatusCode , result.Message);
            }
            return Ok(result);
        }
    }
}
