using MediatR;
using QuickBasket.Application.Features.Carts.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Domain.Entities;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Carts.Handler
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Result<int>>
    {
        private readonly ICartRepository _cartRepository;

        public CreateCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        
        public async Task<Result<int>> Handle(CreateCartCommand request , CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                UserId = request.UserId,
                SessionId = request.SessionId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };
            var result = await _cartRepository.CreateCartAsync(cart);
            return Result<int>.Success(result, 201);
        }
    }
}
