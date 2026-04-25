using MediatR;
using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Queries
{
    public class GetAllCartItemQuery : IRequest<Result<List<CartItemResponseDto>>>
    {
    }
}
