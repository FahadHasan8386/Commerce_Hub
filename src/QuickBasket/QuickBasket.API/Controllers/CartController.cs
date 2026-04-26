using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBasket.Application.Features.Carts.Commands;
using QuickBasket.Application.Features.Carts.DTOs;
using QuickBasket.Application.Features.Carts.Queries;
using QuickBasket.Application.Features.Orders.Commands;
using QuickBasket.Application.Features.Orders.Queries;

namespace QuickBasket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCart()
        {
            var query = new GetAllCartQuery();
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(int id)
        {
            var query = new GetCartByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCartCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, UpdateCartCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var command = new DeleteCartCommand(id);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return NoContent();
        }
    }
}
