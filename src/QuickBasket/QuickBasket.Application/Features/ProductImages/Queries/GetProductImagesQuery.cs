using MediatR;
using QuickBasket.Application.Features.ProductImage.DTOs;
using QuickBasket.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Features.ProductImage.Queries
{
    public class GetProductImagesQuery : IRequest<Result<List<ProductImageResponseDto>>>
    {
    }
}
