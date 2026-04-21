using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.Commands
{
    public class DeleteProductImageCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public DeleteProductImageCommand(int id)
        {
            Id = id;
        }
    }
}
