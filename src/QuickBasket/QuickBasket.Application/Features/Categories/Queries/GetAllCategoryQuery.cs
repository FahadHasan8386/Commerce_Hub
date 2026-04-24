using MediatR;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Categories.Queries
{
    public class GetAllCategoryQuery : IRequest<Result<List<CategoryResponseDto>>>
    {
    }
}
