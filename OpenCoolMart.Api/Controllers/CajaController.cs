using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;

namespace OpenCoolMart.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        private readonly ICajaService _cajaService;
        private readonly IMapper _mapper;

        public CajaController(ICajaService cajaService, IMapper mapper)
        {
            _cajaService = cajaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cajas = await _cajaService.GetCajas();
            var cajasDto = _mapper.Map<IEnumerable<Caja>, IEnumerable<CajaResponseDto>>(cajas);
            var response = new ApiResponse<IEnumerable<CajaResponseDto>>(cajasDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var caja = await _cajaService.GetCaja(id);
            var cajaDto = _mapper.Map<Caja, CajaResponseDto>(caja);
            var response = new ApiResponse<CajaResponseDto>(cajaDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CajaRequestDto cajalDto)
        {
            var caja = _mapper.Map<CajaRequestDto, Caja>(cajalDto);
            await _cajaService.AddCaja(caja);
            var cajaresponseDto = _mapper.Map<Caja, CajaResponseDto>(caja);
            var response = new ApiResponse<CajaResponseDto>(cajaresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _cajaService.DeleteCaja(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CajaResponseDto cajaResponse)
        {
            var caja = _mapper.Map<Caja>(cajaResponse);
            caja.Id = id;
            caja.UpdateAt = DateTime.Now;
            caja.UpdatedBy = 1;
            await _cajaService.UpdateCaja(caja);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}