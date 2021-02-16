using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CajaRequestDto = OpenCoolMart.Gui.Models.CajaRequestDto;
using CajaResponseDto = OpenCoolMart.Gui.Models.CajaResponseDto;

namespace OpenCoolMart.Gui.Controllers
{
    public class CajaController:Controller
    {
        HttpClient client = new HttpClient();
        string url = "https://localhost:44315/api/Caja/";
        public async Task<IActionResult> Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
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
            var Token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var Json = await client.PostAsJsonAsync("https://localhost:44315/api/Caja/", Caja);
            if (Json.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(Caja);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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
            var Token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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
