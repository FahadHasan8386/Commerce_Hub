using QuickBasket.Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Handler
{
    public class GetByCartItemIdQueryHandler
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetByCartItemIdQueryHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
    }
}
