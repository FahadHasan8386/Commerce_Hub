using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBasket.Application.Features.Products.Commands;
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

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await Mediator.Send(command);

            if(!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return CreatedAtAction(nameof(GetProduct), new { id = result.Data }, result.Data);
        }
    }
}
