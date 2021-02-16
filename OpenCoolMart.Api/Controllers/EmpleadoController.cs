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
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;
        public EmpleadoController(IEmpleadoService empleadoService, IMapper mapper)
        {
            this._empleadoService = empleadoService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empleados = await _empleadoService.GetEmpleados();
            var empleadosDto = _mapper.Map<IEnumerable<Empleado>, IEnumerable<EmpleadoResponseDto>>(empleados);
            var response = new ApiResponse<IEnumerable<EmpleadoResponseDto>>(empleadosDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var empleado = await _empleadoService.GetEmpleado(id);
            var empleadoDto = _mapper.Map<Empleado, EmpleadoResponseDto>(empleado);
            var response = new ApiResponse<EmpleadoResponseDto>(empleadoDto);

            return Ok(response);
        }
        [HttpGet("emp/{id:int}")]
        public async Task<IActionResult> GetByCode(int id)
        {
            var empleados = await _empleadoService.GetEmpleados();
            var empleado = empleados.SingleOrDefault(em => em.CodigoEmpleado == id);
            var empleadoDto = _mapper.Map<Empleado, EmpleadoResponseDto>(empleado);
            var response = new ApiResponse<EmpleadoResponseDto>(empleadoDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmpleadoRequestDto empleadolDto)
        {
            var empleado = _mapper.Map<EmpleadoRequestDto, Empleado>(empleadolDto);
            await _empleadoService.AddEmpleado(empleado);
            var empleadoresponseDto = _mapper.Map<Empleado, EmpleadoResponseDto>(empleado);
            var response = new ApiResponse<EmpleadoResponseDto>(empleadoresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _empleadoService.DeleteEmpleado(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, EmpleadoResponseDto empleadoResponse)
        {
            var empleado = _mapper.Map<Empleado>(empleadoResponse);
            empleado.Id = id;
            empleado.UpdateAt = DateTime.Now;
            empleado.UpdatedBy = 1;
            await _empleadoService.UpdateEmpleado(empleado);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
