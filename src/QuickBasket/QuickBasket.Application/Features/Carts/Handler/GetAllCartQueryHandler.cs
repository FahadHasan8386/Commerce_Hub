using MediatR;
using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Application.Features.CartItems.Queries;
using QuickBasket.Application.Features.Carts.DTOs;
using QuickBasket.Application.Features.Carts.Queries;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Handler
{
    public class GetAllCartQueryHandler : IRequestHandler<GetAllCartQuery, Result<List<CartResponseDto>>>
    {
        private readonly ICartRepository _cartRepository;

        public GetAllCartQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Result<List<CartResponseDto>>> Handle(GetAllCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetAllAsync();

            if (cart == null)
            {
                return Result<List<CartResponseDto>>.Failure("Cart Item not found ", 404);
            }

            return Result<List<CartResponseDto>>.Success(cart, 200);
        }
    }
}
