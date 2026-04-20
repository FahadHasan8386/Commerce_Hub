using MediatR;
using QuickBasket.Application.Features.ProductImage.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImages.Queries
{
    public class GetProductImageByIdQuery : IRequest<Result<ProductImageDto>>
    {
        public int Id { get; set; }

        public GetProductImageByIdQuery(int id)
        {
            Id = id;
        }
    }
}
