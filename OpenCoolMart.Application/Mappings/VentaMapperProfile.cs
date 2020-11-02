using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using System;

namespace OpenCoolMart.Application.Mappings
{
    public class VentaMapperProfile:Profile
    {
        public VentaMapperProfile()
        {
            CreateMap<Venta, VentaRequestDto>();
            CreateMap<Venta, VentaResponseDto>();
            CreateMap<VentaRequestDto, Venta>().AfterMap(
                ((source, destination) =>
                {
                    destination.CreateAt = DateTime.Now;
                    destination.CreatedBy = 1;
                    destination.Status = true;
                }));
            CreateMap<VentaResponseDto, Venta>();
        }        
    }
}
