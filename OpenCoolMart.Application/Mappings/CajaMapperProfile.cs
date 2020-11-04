using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using System;

namespace OpenCoolMart.Application.Mappings
{
    public class CajaMapperProfile:Profile
    {
        public CajaMapperProfile()
        {
            CreateMap<Caja, CajaRequestDto>();
            CreateMap<Caja, CajaResponseDto>();
            CreateMap<CajaRequestDto, Caja>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<CajaResponseDto, Caja>();
        }
    }
}
