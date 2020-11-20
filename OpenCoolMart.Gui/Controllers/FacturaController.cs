﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
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
                string json = await client.GetStringAsync("https://localhost:44315/api/venta/");
                var Listventas = JsonConvert.DeserializeObject<ApiResponse<List<VentaResponseDto>>>(json);
                List<SelectListItem> Ventas = Listventas.Data.ConvertAll(Ven =>
                {
                    return new SelectListItem()
                    {
                        Text = Ven.Id.ToString(),
                        Value = Ven.Id.ToString(),
                        Selected = false
                    };
                });
                ViewBag.Ventas = Ventas;
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
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
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
                var json = await client.GetStringAsync(url+id);
                var _Factura = JsonConvert.DeserializeObject<ApiResponse<FacturaRequestDto>>(json);
                return View(_Factura.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPut]
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
    }
}

