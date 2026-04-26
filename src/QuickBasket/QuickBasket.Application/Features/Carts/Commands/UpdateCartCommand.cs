using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Carts.Commands
{
    public class UpdateCartCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public bool? IsCheckedOut { get; set; }

    }
}
