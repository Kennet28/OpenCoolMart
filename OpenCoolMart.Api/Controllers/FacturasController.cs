using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Application.Services;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;


namespace OpenCoolMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturasService _facturasService;
        private readonly IMapper _mapper;
        public FacturasController(IFacturasService facturasService, IMapper mapper)
        {
            _facturasService = facturasService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facturas = await _facturasService.GetFacturas();
            var facturasDto = _mapper.Map<IEnumerable<Facturas>, IEnumerable<FacturaResponseDto>>(facturas);
            var response = new ApiResponse<IEnumerable<FacturaResponseDto>>(facturasDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var factura = await _facturasService.GetFactura(id);
            var facturaDto = _mapper.Map<Facturas, FacturaResponseDto>(factura);
            var response = new ApiResponse<FacturaResponseDto>(facturaDto);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(FacturaRequestDto facturalDto)
        {
            var factura = _mapper.Map<FacturaRequestDto, Facturas>(facturalDto);
            await _facturasService.AddFactura(factura);
            var facturaresponseDto = _mapper.Map<Facturas, FacturaResponseDto>(factura);
            var response = new ApiResponse<FacturaResponseDto>(facturaresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _facturasService.DeleteFactura(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, FacturaResponseDto facturaResponse)
        {
            var factura = _mapper.Map<Facturas>(facturaResponse);
            factura.Id = id;
            factura.UpdateAt = DateTime.Now;
            factura.UpdatedBy = 1;
            await _facturasService.UpdateFactura(factura);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
