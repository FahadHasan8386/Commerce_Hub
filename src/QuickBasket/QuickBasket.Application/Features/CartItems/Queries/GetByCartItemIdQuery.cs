using MediatR;
using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Queries
{
    public class GetByCartItemIdQuery : IRequest<Result<CartItemResponseDto>>
    {
        public int Id {  get; set; }
    }
}
