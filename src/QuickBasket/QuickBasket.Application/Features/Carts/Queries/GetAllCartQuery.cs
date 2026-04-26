using MediatR;
using QuickBasket.Application.Features.Carts.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Queries
{
    public class GetAllCartQuery : IRequest<Result<List<CartResponseDto>>>
    {

    }
}
