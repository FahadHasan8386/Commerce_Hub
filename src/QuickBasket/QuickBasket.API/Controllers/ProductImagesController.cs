using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBasket.Application.Features.ProductImages.Commands;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Features.ProductImages.Queries;

namespace QuickBasket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImage()
        {
            var query = new GetProductImagesQuery();
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(int id)
        {
            var query = new GetProductImageByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage([FromBody] CreateProductImageDto dto)
        {
            var command = new CreateProductImageCommand
            {
                ImageUrl = dto.ImageUrl,
                IsPrimary = dto.IsPrimary,
                ProductId = dto.ProductId
            };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductImage(int id, [FromBody] UpdateProductImageDto dto)
        {
            var command = new UpdateProductImageCommand
            {
                Id = id,
                ImageUrl = dto.ImageUrl,
                IsPrimary = dto.IsPrimary,
                ProductId = dto.ProductId
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var command = new DeleteProductImageCommand(id);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }

            return NoContent();
        }
    }
}
