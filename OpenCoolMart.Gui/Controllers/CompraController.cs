using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Controllers
{
    public class CompraController : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var httpClient = new HttpClient();
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Compra");
                var Listcompras = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<CompraResponseDto>>>(Json);
                return View(Listcompras.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Details(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var httpClient = new HttpClient();
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Compra/" + Id);
                var compra = JsonConvert.DeserializeObject<ApiResponse<CompraResponseDto>>(Json);
                return View(compra.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Create()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                ViewData["Usuario"] = HttpContext.Session.GetString("Id");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
