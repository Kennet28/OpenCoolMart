using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Domain.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCoolMart.Api.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetAll([FromQuery]VentaQueryFilter filter)
        {
            var ventas = _service.GetVentas(filter);
            var ventasDto = _mapper.Map<IEnumerable<Venta>, IEnumerable<VentaResponseDto>>(ventas);
            var response = new ApiResponse<IEnumerable<VentaResponseDto>>(ventasDto);
            await Task.Delay(10);
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
            VentaQueryFilter filter= new VentaQueryFilter();
            var ventas = _service.GetVentas(filter);
            Venta nuevaventa= new Venta();
            if (ventas.Any())
            {
                nuevaventa = ventas.Last();
                 
            }
            else
            {
                nuevaventa.Folio = 100000;
            }
            var venta = _mapper.Map<VentaRequestDto, Venta>(ventaDto);
            venta.Folio = nuevaventa.Folio + 1;
            await _service.CrearVerta(venta);
            var ventaResponseDto = _mapper.Map<Venta, VentaResponseDto>(venta);
            return Ok(ventaResponseDto);
        }
       
    }
}
