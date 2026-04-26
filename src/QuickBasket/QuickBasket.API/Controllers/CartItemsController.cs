using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBasket.Application.Features.CartItems.Commands;
using QuickBasket.Application.Features.CartItems.Queries;
using QuickBasket.Application.Features.Products.Commands;
using QuickBasket.Application.Features.Products.Queries;

namespace QuickBasket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartItemsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var query = new GetAllCartItemQuery();
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemById(int id)
        {
            var query = new GetByCartItemIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItem([FromBody] CreateCartItemCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return StatusCode(result.StatusCode, result.ErrorMessage);

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, [FromBody] UpdateCartItemCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return StatusCode(result.StatusCode, result.ErrorMessage);
            
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var command = new DeleteCartItemCommand(id);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return NoContent();
        }
    }
}
