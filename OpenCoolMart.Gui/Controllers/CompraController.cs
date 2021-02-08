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
    public class CompraController : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Compra");
                var Listcompras = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<CompraResponseDto>>>(Json);
                return View(Listcompras.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Details(int Id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Compra/" + Id);
                var compra = JsonConvert.DeserializeObject<ApiResponse<CompraResponseDto>>(Json);
                return View(compra.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Create()
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
    }
}
