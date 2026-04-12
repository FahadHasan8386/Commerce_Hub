using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<Result<bool>>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
