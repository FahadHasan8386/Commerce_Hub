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
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);

            if(!result.IsSuccess)
            {
                return StatusCode(result.StatusCode , result.ErrorMessage);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return CreatedAtAction(nameof(GetProduct), new { id = result.Data }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return Ok(result.Data); 
        }
    }
}
