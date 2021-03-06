﻿using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Application.Mappings
{
    public class ProductoMapperProfile:Profile
    {
        public ProductoMapperProfile()
        {
            CreateMap<Producto, ProductoRequestDto>();
            CreateMap<Producto, ProductoResponseDto>();
            CreateMap<ProductoRequestDto, Producto>().ForMember(x => x.Imagen, options => options.Ignore()); 

            CreateMap<ProductoResponseDto, Producto>();
        }
    }
}
