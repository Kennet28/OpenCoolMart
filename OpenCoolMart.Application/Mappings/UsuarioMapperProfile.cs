using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using System;

namespace OpenCoolMart.Application.Mappings
{
    public class UsuarioMapperProfile:Profile
    {
        public int CreatedBy { get; set; }
        public UsuarioMapperProfile()
        {
            CreateMap<Usuario, UsuarioRequestDto>();
            CreateMap<Usuario, UsuarioResponseDto>();
            CreateMap<UsuarioRequestDto, Usuario>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<UsuarioResponseDto, Usuario>();
        }
    }
}
