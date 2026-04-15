using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
