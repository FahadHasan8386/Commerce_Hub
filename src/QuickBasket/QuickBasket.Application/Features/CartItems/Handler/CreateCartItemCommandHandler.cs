using MediatR;
using QuickBasket.Application.Features.CartItems.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Handler
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand , Result<int>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CreateCartItemCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result<int>> Handle(CreateCartItemCommand request , CancellationToken cancellationToken)
        {
            var cartItem = new CartItems
            {
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                CartId = request.CartId,
                ProductId = request.ProductId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System",
                IsDeleted = false
            };

            var result = await _cartItemRepository.CreateCartItemAsync(cartItem);
            return Result<int>.Success(cartItem, 201);
        }
    }
}