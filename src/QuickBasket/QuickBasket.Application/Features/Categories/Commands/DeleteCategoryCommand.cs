using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<Result<bool>>
    {

        public int Id { get; set; }
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

    }
}
