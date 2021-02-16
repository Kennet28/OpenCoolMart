using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCoolMart.Api.Controllers
{
    [Authorize(Roles ="1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;
        private readonly IMapper _mapper;
        public ProveedorController(IProveedorService proveedorService, IMapper mapper)
        {
            this._proveedorService = proveedorService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _proveedorService.GetProveedores();
            var proveedoresDto = _mapper.Map<IEnumerable<Proveedor>, IEnumerable<ProveedorResponseDto>>(proveedores);
            var response = new ApiResponse<IEnumerable<ProveedorResponseDto>>(proveedoresDto);
            if (proveedoresDto.Count() <= 0)
                return Ok(response);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var proveedor = await _proveedorService.GetProveedor(id);
            var proveedorDto = _mapper.Map<Proveedor, ProveedorResponseDto>(proveedor);
            var response = new ApiResponse<ProveedorResponseDto>(proveedorDto);
            /*if (proveedor.Status == false)
                return Ok(response);*/
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(ProveedorRequestDto proveedorlDto)
        {
            var proveedor = _mapper.Map<ProveedorRequestDto, Proveedor>(proveedorlDto);
            proveedor.CreateAt = DateTime.Now;
            await _proveedorService.AddProveedor(proveedor);
            var proveedorresponseDto = _mapper.Map<Proveedor, ProveedorResponseDto>(proveedor);
            var response = new ApiResponse<ProveedorResponseDto>(proveedorresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _proveedorService.DeleteProveedor(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ProveedorRequestDto proveedorResponse)
        {
            var proveedor = _mapper.Map<Proveedor>(proveedorResponse);
            proveedor.Id = id;
            proveedor.UpdateAt = DateTime.Now;
            await _proveedorService.UpdateProveedor(proveedor);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
