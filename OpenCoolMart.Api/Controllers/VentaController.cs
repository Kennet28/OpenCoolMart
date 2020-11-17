using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenCoolMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _service;
        private readonly IMapper _mapper;
        public VentaController(IVentaService service,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ventas = await _service.GetAll();
            var ventasDto = _mapper.Map<IEnumerable<Venta>, IEnumerable<VentaResponseDto>>(ventas);
            var response = new ApiResponse<IEnumerable<VentaResponseDto>>(ventasDto);
            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            var venta =await _service.VerVenta(Id);
            var ventaDto = _mapper.Map<Venta, VentaResponseDto>(venta);
            var response = new ApiResponse<VentaResponseDto>(ventaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VentaRequestDto ventaDto)
        {
            var venta = _mapper.Map<VentaRequestDto, Venta>(ventaDto);
            await _service.CrearVerta(venta);
            var ventaResponseDto = _mapper.Map<Venta, VentaResponseDto>(venta);
            return Ok(ventaResponseDto);
        }
    }
}
