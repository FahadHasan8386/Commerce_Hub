using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.CartItems.Commands
{
    public class DeleteCartItemCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }

        public DeleteCartItemCommand(int id)
        {
            Id = id;
        }

    }
}
