using MediatR;
using QuickBasket.Application.Features.CartItems.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Domain.Entities;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Handler
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand ,Result<int>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public UpdateCartItemCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result<int>> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new CartItem
            {
                Id = request.Id,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                CartId = request.CartId,
                ProductId = request.ProductId,
                ModifiedAt = DateTime.Now,
                ModifiedBy = "System"
            };

            var result = await _cartItemRepository.UpdateCartItemAsync(cartItem);
            return Result<int>.Success(result, 201);
        }
    }
}
