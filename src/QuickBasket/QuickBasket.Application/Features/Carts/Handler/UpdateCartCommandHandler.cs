using MediatR;
using QuickBasket.Application.Features.Carts.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Domain.Entities;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Handler
{
    public class UpdateCartCommandHandler : IRequestHandler <UpdateCartCommand, Result<int>>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Result<int>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                Id = request.Id,
                IsCheckedOut = request.IsCheckedOut ?? false,
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = "System"
            };
            var result = await _cartRepository.UpdateCartAsync(cart);
            if(result == 0)
            {
                return Result<int>.Failure("Update Failed", 400);
            }
            return Result<int>.Success(result, 201);
        }
    }
}
