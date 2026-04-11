using Dapper;
using MediatR;
using QuickBasket.Application.Features.Products.DTOs;
using QuickBasket.Application.Features.Products.Queries;
using QuickBasket.Application.Interfaces;
using QuickBasket.Shared.Helpers;

namespace QuickBasket.Application.Features.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        private readonly IDapperContext _context;

        public GetProductByIdQueryHandler(IDapperContext context)
        {
            _context = context;
        }

        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request,CancellationToken cancellationToken)
        {
            var sql = @"
                SELECT 
                    Id,
                    Name,
                    Price
                FROM Products
                WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            var product = await connection.QueryFirstOrDefaultAsync<ProductDto>(
                sql,
                new { Id = request.Id }
            );

            if (product == null)
            {
                return Result<ProductDto>.Failure($"Product with Id {request.Id} not found");
            }

            return Result<ProductDto>.Success(product);
        }
    }
}