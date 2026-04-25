using MediatR;
using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Application.Features.CartItems.Queries;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Features.Products.Queries;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Handler
{
    public class GetAllCartItemQueryHandler : IRequestHandler<GetAllCartItemQuery , Result<List<CartItemResponseDto>>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetAllCartItemQueryHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task<Result<List<CartItemResponseDto>>> Handle(GetAllCartItemQuery request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.GetAllAsync();

            if (cartItem == null)
            {
                return Result<List<CartItemResponseDto>>.Failure("Cart Item not found ", 404);
            }

            return Result<List<CartItemResponseDto>>.Success(cartItem, 200);
        }
    }
}
