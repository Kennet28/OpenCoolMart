using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Venta");
            var Listventas = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<VentaResponseDto>>>(Json);
            return View(Listventas.Data);
        }
        public async Task <IActionResult> Details(int Id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Venta/" + Id);
            var venta = JsonConvert.DeserializeObject<ApiResponse<VentaResponseDto>>(Json);
            return View(venta.Data);
        }
    }
}
