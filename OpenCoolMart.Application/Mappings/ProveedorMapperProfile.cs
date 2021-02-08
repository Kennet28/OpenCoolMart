using AutoMapper;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Application.Mappings
{
    public class ProveedorMapperProfile:Profile
    {
        public ProveedorMapperProfile()
        {
            CreateMap<Proveedor, ProveedorRequestDto>();
            CreateMap<Proveedor, ProveedorResponseDto>();
            CreateMap<ProveedorRequestDto, Proveedor>().AfterMap(
            ((source, destination) => {
            }));
            CreateMap<ProveedorResponseDto, Proveedor>();
        }
    }
}
