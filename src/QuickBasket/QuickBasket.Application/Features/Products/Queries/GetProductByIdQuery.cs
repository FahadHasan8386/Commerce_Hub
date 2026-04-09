using MediatR;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Result<ProductDto>>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
