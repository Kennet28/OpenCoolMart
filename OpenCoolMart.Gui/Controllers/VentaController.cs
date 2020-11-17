using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
>>>>>>> 219c194347e2674694a45b8e46c8ca18c23ba6b0

namespace OpenCoolMart.Gui.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
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
<<<<<<< HEAD
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
=======
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Venta");
                var Listventas = JsonConvert.DeserializeObject<List<VentaResponseDto>>(Json);
                return View(Listventas);
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
                var venta = JsonConvert.DeserializeObject<VentaResponseDto>(Json);
                return View(venta);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
>>>>>>> 219c194347e2674694a45b8e46c8ca18c23ba6b0
        }
    }
}
