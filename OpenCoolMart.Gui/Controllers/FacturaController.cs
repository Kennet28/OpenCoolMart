using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Gui.Enumerations;
using OpenCoolMart.Gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
                var json = await client.GetStringAsync(url);
                var Facturas = JsonConvert.DeserializeObject<ApiResponse<List<FacturaResponseDto>>>(json);
                return View(Facturas.Data);
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

            Factura.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var Json = await client.PostAsJsonAsync("https://localhost:44315/api/Facturas/", Factura);
            if (Json.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(Factura);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44315/api/facturas/"+id);
                var _Factura = JsonConvert.DeserializeObject<ApiResponse<FacturaResponseDto>>(json);
                return View(_Factura.Data);
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
                ViewBag.Ventas = await GetVentasAsync();
                ViewBag.Clientes = await GetClientesAsync(); ;
                ViewBag.UsosCFDI = GetUsosCfdi();
                var json = await client.GetStringAsync("https://localhost:44315/api/facturas/"+id);
                var _Factura = JsonConvert.DeserializeObject<ApiResponse<FacturaRequestDto>>(json);
                return View(_Factura.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id,FacturaRequestDto FacturaDto)
        {
            client.BaseAddress = new Uri("https://localhost:44315/api/facturas/");
            FacturaDto.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var putTask = await client.PutAsJsonAsync("?id=" + Id, FacturaDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(FacturaDto);
        }
        public async Task<List<SelectListItem>> GetVentasAsync() 
        {
            string json = await client.GetStringAsync("https://localhost:44315/api/venta/");
            var Listventas = JsonConvert.DeserializeObject<ApiResponse<List<Models.VentaResponseDto>>>(json);
            List<SelectListItem> Ventas = Listventas.Data.ConvertAll(Ven =>
            {
                return new SelectListItem()
                {
                    Text = Ven.Id.ToString(),
                    Value = Ven.Id.ToString(),
                    Selected = false
                };
            });
            return Ventas;

        }
    public async Task<List<SelectListItem>> GetClientesAsync()
        {
            string json2 = await client.GetStringAsync("https://localhost:44315/api/cliente/");
            var Listclientes = JsonConvert.DeserializeObject<ApiResponse<List<ClienteResponseDto>>>(json2);
            List<SelectListItem> Clientes = Listclientes.Data.ConvertAll(client =>
            {
                return new SelectListItem()
                {
                    Text = client.Nombre,
                    Value = client.Id.ToString(),
                    Selected = false
                };
            });
            return Clientes;
        }
        public List<SelectListItem> GetUsosCfdi() 
        {
             List<SelectListItem> usosCFDIs = Enum.GetValues(typeof(UsosCFDI)).Cast<UsosCFDI>().ToList().ConvertAll(uso => {
                return new SelectListItem()
                {
                    Text = uso.ToString(),
                    Value = uso.ToString()
                };
            });
            return usosCFDIs;
        }
    }
}

