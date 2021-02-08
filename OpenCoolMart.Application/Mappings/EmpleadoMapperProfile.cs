using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using System;

namespace OpenCoolMart.Application.Mappings
{
    public class EmpleadoMapperProfile:Profile
    {
        public EmpleadoMapperProfile()
        {
            CreateMap<Empleado, EmpleadoRequestDto>();
            CreateMap<Empleado, EmpleadoResponseDto>();
            CreateMap<EmpleadoRequestDto, Empleado>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.Status = true;
            }));
            CreateMap<EmpleadoResponseDto, Empleado>();
        }
    }
}
