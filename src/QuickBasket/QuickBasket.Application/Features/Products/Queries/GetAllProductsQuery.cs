using MediatR;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<Result<ProductResponseDto>>
    {

    }
}
