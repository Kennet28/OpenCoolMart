using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetString("Id") != null)
            {
                ViewData["Usuario"] = HttpContext.Session.GetString("Id");
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Venta");
                var Listventas = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<VentaResponseDto>>>(Json);
                return View(Listventas.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        public async Task <IActionResult> Details(int Id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Venta/" + Id);
                var venta = JsonConvert.DeserializeObject<ApiResponse<VentaResponseDto>>(Json);
                return View(venta.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}
