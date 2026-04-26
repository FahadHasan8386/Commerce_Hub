using MediatR;
using QuickBasket.Application.Features.CartItems.Commands;
using QuickBasket.Application.Features.Carts.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Handler
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand , Result<bool>>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Result<bool>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(request.Id);

            if (cart == null)
            {
                return Result<bool>.Failure("Cart Item not found", 404);
            }
            await _cartRepository.DeleteCartAsync(request.Id);

            return Result<bool>.Success(true, 200);
        }
    }
}
