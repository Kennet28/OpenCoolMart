using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CajaController:Controller
    {
        HttpClient client = new HttpClient();
        string url = "https://localhost:44315/api/Caja/";
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Cajas = JsonConvert.DeserializeObject<ApiResponse<List<CajaResponseDto>>>(json);
                return View(Cajas.Data);
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
                return RedirectToAction("Index","Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CajaRequestDto Caja)
        {
            Caja.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var Json = await client.PostAsJsonAsync("https://localhost:44315/api/Caja/", Caja);
            if (Json.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(Caja);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44315/api/Caja/"+id);
                var _Caja = JsonConvert.DeserializeObject<ApiResponse<CajaResponseDto>>(json);
                return View(_Caja.Data);
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
                var json = await client.GetStringAsync("https://localhost:44315/api/Caja/" + id);
                var _Caja = JsonConvert.DeserializeObject<ApiResponse<CajaRequestDto>>(json);
                return View(_Caja.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id,CajaRequestDto CajaDto)
        {
            client.BaseAddress = new Uri("https://localhost:44315/api/Caja/");
            CajaDto.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var putTask = await client.PutAsJsonAsync("?id=" + Id, CajaDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(CajaDto);
        }
    }
}
