using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Domain.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenCoolMart.Api.Controllers
{
    [Authorize(Roles ="1")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _service;
        private readonly IMapper _mapper;

        public CompraController(ICompraService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]CompraQueryFilter filter)
        {
            var compras = _service.GetCompras(filter);
            var comprasDto = _mapper.Map<IEnumerable<Compra>, IEnumerable<CompraResponseDto>>(compras);
            var response = new ApiResponse<IEnumerable<CompraResponseDto>>(comprasDto);
            await Task.Delay(10);
            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {

            var compra = await _service.VerCompra(Id);
            var CompraDto = _mapper.Map<Compra, CompraResponseDto>(compra);            
            var response = new ApiResponse<CompraResponseDto>(CompraDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompraRequestDto ventaDto)
        {
            var compra = _mapper.Map<CompraRequestDto, Compra>(ventaDto);
            
            await _service.CrearCompra(compra);
            var ventaResponseDto = _mapper.Map<Compra, CompraResponseDto>(compra);
            return Ok(ventaResponseDto);
        }
    }
}
