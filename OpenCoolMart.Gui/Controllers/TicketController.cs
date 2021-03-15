using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System.Threading.Tasks;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Gui.Handler;
using Wkhtmltopdf.NetCore;

namespace OpenCoolMart.Gui.Controllers
{
    public class TicketController : Controller
    {
         private readonly IGeneratePdf _generatePdf;
                public TicketController(IGeneratePdf generatePdf)
                {
                    _generatePdf = generatePdf;
                }
                public async Task<IActionResult> GetPdf(int Id)
                {
                   if (HttpContext.Session.GetString("Id") != null)
                   {
                       var httpClient = new HttpClient(ByPassSsl.GetHandler());
                        var Token = HttpContext.Session.GetString("Token");
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        var Json = await httpClient.GetStringAsync("https://opencoolmart.somee.com/Venta/" + Id);
                        var venta = JsonConvert.DeserializeObject<ApiResponse<VentaResponseDto>>(Json);
                        var Json2 = await httpClient.GetStringAsync("https://opencoolmart.somee.com/empleado/" + venta.Data.EmpleadoId);
                        var empleado = JsonConvert.DeserializeObject<ApiResponse<EmpleadoResponseDto>>(Json2);
                        venta.Data.Empleado = empleado.Data;
                        return await _generatePdf.GetPdf("Reportes/Details.cshtml",venta.Data);
                   }
                   else
                   {
                        return RedirectToAction("GetVentas","Venta");
                   }
                }
    }
}