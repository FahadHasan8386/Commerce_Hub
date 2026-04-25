using MediatR;
using QuickBasket.Application.Features.CartItems.Commands;
using QuickBasket.Application.Features.Products.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Handler
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, Result<bool>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public DeleteCartItemCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Result<bool>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(request.Id);

            if (cartItem == null)
            {
                return Result<bool>.Failure("Cart Item not found", 404);
            }
            await _cartItemRepository.DeleteCartItemAsync(request.Id);

            return Result<bool>.Success(true, 200);
        }
    }
}
