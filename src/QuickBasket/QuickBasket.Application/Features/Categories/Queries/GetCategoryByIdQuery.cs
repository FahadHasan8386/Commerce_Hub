using MediatR;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Result<CategoryResponseDto>>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
