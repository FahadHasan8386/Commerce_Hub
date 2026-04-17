using MediatR;
using QuickBasket.Application.Features.Orders.DTOs;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<Result<List<OrderResponseDto>>>
    {
    }
}
