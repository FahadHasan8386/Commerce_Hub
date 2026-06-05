using MediatR;
using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.CartItems.Commands;
using QuickBasket.Application.Interfaces.IRepository;
using QuickBasket.Domain.Entities;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Handler
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand , Result<int>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public CreateCartItemCommandHandler(ICartItemRepository cartItemRepository,IProductRepository productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<int>> Handle(CreateCartItemCommand request , CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if(product == null)
            {
                return Result<int>.Failure("Product Not Found", 404);
            }

            var cartItem = new CartItem
            {
                CartId = request.CartId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = product.Price,

                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System",
                IsDeleted = false
            };

            var id = await _cartItemRepository.CreateCartItemAsync(cartItem);

            return Result<int>.Success(id, 201);
        }
    }
}