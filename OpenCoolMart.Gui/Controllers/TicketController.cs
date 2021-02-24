using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Controllers
{
    public class TicketController : Controller
    {
        // GET
        public async Task<IActionResult> Index(int Id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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