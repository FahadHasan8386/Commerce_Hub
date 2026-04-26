using MediatR;
using QuickBasket.Application.Features.Carts.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Queries
{
    public class GetCartByIdQuery : IRequest<Result<CartResponseDto>>
    {
        public int Id { get; set; }
        public GetCartByIdQuery(int id)
        {
            Id = id;
        }
    }
}
