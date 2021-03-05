using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using Wkhtmltopdf.NetCore;

namespace OpenCoolMart.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly IEmpleadoService _empleadoService;
        private readonly IVentaService _ventaService;
        private readonly IMapper _mapper;
        public TicketController(IGeneratePdf generatePdf,IVentaService ventaService,IMapper mapper,IEmpleadoService empleadoService)
        {
            _generatePdf = generatePdf;
            _ventaService = ventaService;
            _mapper = mapper;
            _empleadoService = empleadoService;
        }
        [HttpGet("{id:int}")]
        
        public async Task<IActionResult> Get(int id)
        {
                var venta =await _ventaService.VerVenta(id);
                var ventaDto = _mapper.Map<Venta, VentaResponseDto>(venta);
                var empleado = await _empleadoService.GetEmpleado(ventaDto.EmpleadoId);
                var empleadoDto = _mapper.Map<Empleado, EmpleadoResponseDto>(empleado);
                ventaDto.Empleado = empleadoDto;
                return await _generatePdf.GetPdf("Reportes/Details.cshtml",ventaDto);
        }
    }
}