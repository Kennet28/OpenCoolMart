using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Mappings
{
    class CompraMapperProfile:Profile
    {
        public CompraMapperProfile()
        {
            CreateMap<Compra, CompraRequestDto>();
            CreateMap<Compra, CompraResponseDto>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<CompraRequestDto, Compra>().AfterMap(
                ((source, destination) =>
                {
                    destination.CreateAt = DateTime.Now;
                    destination.Status = true;
                }));
            CreateMap<CompraResponseDto, Compra>();
        }
    }
}
