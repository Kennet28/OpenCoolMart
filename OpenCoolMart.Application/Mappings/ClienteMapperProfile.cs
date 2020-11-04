using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using System;

namespace OpenCoolMart.Application.Mappings
{
    public class ClienteMapperProfile:Profile
    {
        public ClienteMapperProfile()
        {
            CreateMap<Cliente, ClienteRequestDto>();
            CreateMap<Cliente, ClienteResponseDto>();
            CreateMap<ClienteRequestDto, Cliente>().AfterMap(
            ((source, destination) =>{
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<ClienteResponseDto, Cliente>();
        }
    }
}
