using AutoMapper;
using QuickBasket.API.Models.Entities;
using QuickBasket.Application.Features.Products.Commands;
using QuickBasket.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBasket.Application.Mappings
{
    public class MappingProfile : Profile 
    {
        public MappingProfile() 
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product , ProductResponseDto>();
        }
    }
}
