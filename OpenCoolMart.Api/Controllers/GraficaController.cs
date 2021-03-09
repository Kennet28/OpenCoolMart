using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Domain.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCoolMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficaController : ControllerBase
    {
        private readonly IGraficaRepository _service;
        public GraficaController(IGraficaRepository service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GraficaQueryFilter filter)
        {
            var ventas = _service.GetAll(filter);
            await Task.Delay(10);
            return Ok(ventas);
        }
    }
}
