using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;

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
            var Listventas = JsonConvert.DeserializeObject<List<VentaResponseDto>>(Json);
            return View(Listventas);
        }
        public async Task <IActionResult> Details(int Id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Venta/" + Id);
            var venta = JsonConvert.DeserializeObject<VentaResponseDto>(Json);
            return View(venta);
        }
    }
}
