using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Controllers
{
    public class FacturaController : Controller
    {
        HttpClient client = new HttpClient();
        string url = "https://localhost:44315/api/factura/";
        public async Task<IActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Facturas = JsonConvert.DeserializeObject<IList<FacturaResponseDto>>(json);
                return View(Facturas);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
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
            var Json = await client.PostAsJsonAsync("https://localhost:44315/api/Factura/", Factura);
            if (Json.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(Factura);
        }
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Facturas = JsonConvert.DeserializeObject<List<FacturaResponseDto>>(json);
                var _Factura = Facturas.FirstOrDefault(e => e.Id.Equals(id));
                return View(_Factura);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> UpdateAsync(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Facturas = JsonConvert.DeserializeObject<List<FacturaResponseDto>>(json);
                var _Factura = Facturas.FirstOrDefault(e => e.Id.Equals(id));
                return View(_Factura);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(FacturaResponseDto FacturaDto)
        {
            client.BaseAddress = new Uri("https://localhost:44315/api/Factura/");
            FacturaDto.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var putTask = await client.PutAsJsonAsync("?id=" + FacturaDto.Id, FacturaDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(FacturaDto);
        }
    }
}

