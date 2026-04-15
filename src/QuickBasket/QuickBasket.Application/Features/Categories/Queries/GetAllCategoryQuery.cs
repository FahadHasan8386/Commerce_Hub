using MediatR;
using QuickBasket.Application.Features.Categories.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Categories.Queries
{
    public class GetAllCategoryQuery : IRequest<Result<List<CategoryResponseDto>>>
    {
    }
}
