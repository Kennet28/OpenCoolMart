using AutoMapper;
using OpenCoolMart.Gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Mappings
{
    public class ProductoMapperProfile:Profile
    {
        public ProductoMapperProfile()
        {
            CreateMap<ProductoRequestDto, ProductoResponseDto>();
            CreateMap<ProductoResponseDto, ProductoRequestDto > ().ForMember(x => x.Imagen, option => option.Ignore());
        }
    }
}
