using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;

namespace OpenCoolMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            this._clienteService = clienteService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetClientes();
            var clientesDto = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteResponseDto>>(clientes);
            var response = new ApiResponse<IEnumerable<ClienteResponseDto>>(clientesDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _clienteService.GetCliente(id);
            var clienteDto = _mapper.Map<Cliente, ClienteResponseDto>(cliente);
            var response = new ApiResponse<ClienteResponseDto>(clienteDto);

            return Ok(response);
        }
        [HttpGet("cli/{id:alphanumeric}")]
        public async Task<IActionResult> Get(string id)
        {
            var clientes = await _clienteService.GetClientes();
            var cliente = clientes.SingleOrDefault(c => c.Nombre.Contains(id));
            var clienteDto = _mapper.Map<Cliente, ClienteResponseDto>(cliente);
            var response = new ApiResponse<ClienteResponseDto>(clienteDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ClienteRequestDto clientelDto)
        {
            var cliente = _mapper.Map<ClienteRequestDto, Cliente>(clientelDto);
            await _clienteService.AddCliente(cliente);
            var clienteresponseDto = _mapper.Map<Cliente, ClienteResponseDto>(cliente);
            var response = new ApiResponse<ClienteResponseDto>(clienteresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clienteService.DeleteCliente(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ClienteRequestDto clienteResponse)
        {
            var cliente = _mapper.Map<Cliente>(clienteResponse);
            cliente.Id = id;
            cliente.UpdateAt = DateTime.Now;
            cliente.UpdatedBy = 1;
            await _clienteService.UpdateCliente(cliente);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
