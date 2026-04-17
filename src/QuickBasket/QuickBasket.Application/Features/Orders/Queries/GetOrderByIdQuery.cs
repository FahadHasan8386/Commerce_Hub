using MediatR;
using QuickBasket.Application.Features.Orders.DTOs;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<Result<OrderResponseDto>>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
