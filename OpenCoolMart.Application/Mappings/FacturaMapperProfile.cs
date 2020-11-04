using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using System;

namespace OpenCoolMart.Application.Mappings
{
    public class FacturaMapperProfile:Profile
    {
        public FacturaMapperProfile()
        {
            CreateMap<Facturas, FacturaRequestDto>();
            CreateMap<Facturas, FacturaResponseDto>();
            CreateMap<FacturaRequestDto, Facturas>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<FacturaResponseDto, Facturas>();
        }
    }
}
