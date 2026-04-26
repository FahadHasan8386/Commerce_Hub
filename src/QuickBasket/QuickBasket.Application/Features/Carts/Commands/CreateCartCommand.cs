using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Commands
{
    public class CreateCartCommand : IRequest<Result<int>>
    {
        public int? UserId { get; set; }
        public string? SessionId { get; set; }

    }
}
