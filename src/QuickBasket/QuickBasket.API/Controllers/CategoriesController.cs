using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBasket.Application.Features.Categories.Commands;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Application.Features.Categories.Queries;
using QuickBasket.Application.Features.Products.Commands;

namespace QuickBasket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var query = new GetAllCategoryQuery();
            var result = await _mediator.Send(query);

            if(!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto dto)
        {
            var command = new UpdateCategoryCommand
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return NoContent();
        }
    }
}
 