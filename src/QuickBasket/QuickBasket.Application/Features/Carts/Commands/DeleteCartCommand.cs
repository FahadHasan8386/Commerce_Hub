using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Commands
{
    public class DeleteCartCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public DeleteCartCommand(int id)
        {
            Id = id;
        }
    }
}
