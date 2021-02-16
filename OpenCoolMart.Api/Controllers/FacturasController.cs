using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace OpenCoolMart.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        // private readonly IFacturasService _facturasService;
        // private readonly IMapper _mapper;
        // public FacturasController(IFacturasService facturasService, IMapper mapper)
        // {
        //     _facturasService = facturasService;
        //     _mapper = mapper;
        // }
        // [HttpGet]
        // public async Task<IActionResult> GetAll()
        // {
        //     var facturas = await _facturasService.GetFacturas();
        //     var facturasDto = _mapper.Map<IEnumerable<Facturas>, IEnumerable<FacturaResponseDto>>(facturas);
        //     var response = new ApiResponse<IEnumerable<FacturaResponseDto>>(facturasDto);
        //     return Ok(response);
        // }
        //
        // [HttpGet("{id:int}")]
        // public async Task<IActionResult> Get(int id)
        // {
        //     var factura = await _facturasService.GetFactura(id);
        //     var facturaDto = _mapper.Map<Facturas, FacturaResponseDto>(factura);
        //     var response = new ApiResponse<FacturaResponseDto>(facturaDto);
        //
        //     return Ok(response);
        // }
        // [HttpPost]
        // public async Task<IActionResult> Post(FacturaRequestDto facturalDto)
        // {
        //     var facturas = await _facturasService.GetFacturas();
        //     var nuevaFactura = new Facturas();
        //     var facturases = facturas.ToList();
        //     if (facturases.Any()) nuevaFactura = facturases.Last(); else nuevaFactura.Folio = 100000;
        //     var factura = _mapper.Map<FacturaRequestDto, Facturas>(facturalDto);
        //     factura.Folio = nuevaFactura.Folio + 1;
        //     await _facturasService.AddFactura(factura);
        //     var facturaresponseDto = _mapper.Map<Facturas, FacturaResponseDto>(factura);
        //     var response = new ApiResponse<FacturaResponseDto>(facturaresponseDto);
        //     return Ok(response);
        // }
        //
        // [HttpDelete("{id:int}")]
        // public async Task<ActionResult> Delete(int id)
        // {
        //     await _facturasService.DeleteFactura(id);
        //     var result = new ApiResponse<bool>(true);
        //     return Ok(result);
        // }
        //
        // [HttpPut]
        // public async Task<IActionResult> Put(int id, FacturaResponseDto facturaResponse)
        // {
        //     var factura = _mapper.Map<Facturas>(facturaResponse);
        //     factura.Id = id;
        //     factura.UpdateAt = DateTime.Now;
        //     await _facturasService.UpdateFactura(factura);
        //     var result = new ApiResponse<bool>(true);
        //     return Ok(result);
        // }
    }
}
