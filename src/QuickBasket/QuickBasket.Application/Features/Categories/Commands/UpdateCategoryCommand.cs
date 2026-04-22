using MediatR;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
