using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Responses;
using OpenCoolMart.Gui.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OpenCoolMart.Gui.Models;
using System.Net.Http.Headers;

namespace OpenCoolMart.Gui.Controllers
{
    public class FacturaController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string url = "https://localhost:44315/api/facturas/";
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync(url);
                var facturas = JsonConvert.DeserializeObject<ApiResponse<List<FacturaResponseDto>>>(json);
                return View(facturas.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Create()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                ViewBag.Ventas = await GetVentasAsync();
                ViewBag.Clientes = await GetClientesAsync(); ;
                ViewBag.UsosCFDI = GetUsosCfdi();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(FacturaRequestDto Factura)
        {
            ViewBag.Ventas = await GetVentasAsync();
            ViewBag.Clientes = await GetClientesAsync(); ;
            ViewBag.UsosCFDI = GetUsosCfdi();
            Factura.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var Token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var json = await client.PostAsJsonAsync("https://localhost:44315/api/Facturas/", Factura);
            return json.IsSuccessStatusCode ? (IActionResult) RedirectToAction("Index") : View(Factura);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync("https://localhost:44315/api/facturas/"+id);
                var factura = JsonConvert.DeserializeObject<ApiResponse<FacturaResponseDto>>(json);
                return View(factura.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                // ViewBag.Ventas = await GetVentasAsync();
                // ViewBag.Clientes = await GetClientesAsync(); ;
                // ViewBag.UsosCFDI = GetUsosCfdi();
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync("https://localhost:44315/api/facturas/"+id);
                var factura = JsonConvert.DeserializeObject<ApiResponse<FacturaRequestDto>>(json);
                return View(factura.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,FacturaRequestDto facturaDto)
        {
            var Token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.BaseAddress = new Uri("https://localhost:44315/api/facturas/");
            facturaDto.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var putTask = await client.PutAsJsonAsync("?id=" + id, facturaDto);
            return putTask.IsSuccessStatusCode ? (IActionResult) RedirectToAction("Index") : View(facturaDto);
        }
        public async Task<List<SelectListItem>> GetVentasAsync() 
        {
            var Token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            string json = await client.GetStringAsync("https://localhost:44315/api/venta/");
            var listventas = JsonConvert.DeserializeObject<ApiResponse<List<Models.VentaResponseDto>>>(json);
            var ventas = listventas.Data.ConvertAll(ven => new SelectListItem()
            {
                Text = ven.Folio.ToString(),
                Value = ven.Id.ToString(),
                Selected = false
            });
            return ventas;

        }
    public async Task<List<SelectListItem>> GetClientesAsync()
        {
            var Token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            string json2 = await client.GetStringAsync("https://localhost:44315/api/cliente/");
            var listclientes = JsonConvert.DeserializeObject<ApiResponse<List<ClienteResponseDto>>>(json2);
            var clientes = listclientes.Data.ConvertAll(cliente => new SelectListItem()
            {
                Text = cliente.Nombre,
                Value = cliente.Id.ToString(),
                Selected = false
            });
            return clientes;
        }
        public List<SelectListItem> GetUsosCfdi() 
        {
             var usosCFDIs = Enum.GetValues(typeof(UsosCFDI)).Cast<UsosCFDI>().ToList().ConvertAll(uso => new SelectListItem()
             {
                 Text = uso.ToString(),
                 Value = uso.ToString()
             });
            return usosCFDIs;
        }
    }
}

