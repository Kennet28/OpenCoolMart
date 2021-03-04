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
        private readonly IVentaService _service;
        private readonly IMapper _mapper;
        public TicketController(IGeneratePdf generatePdf,IVentaService service,IMapper mapper)
        {
            _generatePdf = generatePdf;
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("{id:int}")]
        
        public async Task<IActionResult> Get(int id)
        {
                var venta =await _service.VerVenta(id);
                var ventaDto = _mapper.Map<Venta, VentaResponseDto>(venta);
                return await _generatePdf.GetPdf("Reportes/Details.cshtml",ventaDto);
        }
    }
}