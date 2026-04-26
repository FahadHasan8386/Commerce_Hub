using MediatR;
using QuickBasket.Application.Features.CartItems.DTOs;
using QuickBasket.Application.Features.Carts.DTOs;
using QuickBasket.Application.Features.Carts.Queries;
using QuickBasket.Application.Features.ProductImages.DTOs;
using QuickBasket.Application.Features.ProductImages.Queries;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Handler
{
    internal class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Result<CartResponseDto>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartByIdQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Result<CartResponseDto>> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.Id);

            if (cart == null)
            {
                return Result<CartResponseDto>.Failure($"Cart with Id {request.Id} not found", 404);
            }
            return Result<CartResponseDto>.Success(cart, 200);
        }
    }
}
