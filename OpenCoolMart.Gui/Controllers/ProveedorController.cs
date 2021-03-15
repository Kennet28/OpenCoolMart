using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OpenCoolMart.Gui.Handler;

namespace OpenCoolMart.Gui.Controllers
{
    public class ProveedorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var httpClient = new HttpClient(ByPassSsl.GetHandler());
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var Json = await httpClient.GetStringAsync("https://opencoolmart.somee.com/api/Proveedor");
                var ListProveedors = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProveedorResponseDto>>>(Json);
                return View(ListProveedors.Data);
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
                var httpClient = new HttpClient(ByPassSsl.GetHandler());
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var Json = await httpClient.GetStringAsync("https://opencoolmart.somee.com/api/Proveedor/" + Id);
                var proveedor = JsonConvert.DeserializeObject<ApiResponse<ProveedorResponseDto>>(Json);
                return View(proveedor.Data);
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
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProveedorRequestDto requestDto)
        {
            requestDto.CreatedBy = Int32.Parse(HttpContext.Session.GetString("Id"));

            var httpClient = new HttpClient(ByPassSsl.GetHandler());
            var Token = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var Json = await httpClient.PostAsJsonAsync("https://opencoolmart.somee.com/api/Proveedor/", requestDto);
            if (Json.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View(requestDto);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var httpClient = new HttpClient(ByPassSsl.GetHandler());
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var Json = await httpClient.GetStringAsync("https://opencoolmart.somee.com/api/Proveedor/" + Id);
                var proveedor = JsonConvert.DeserializeObject<ApiResponse<ProveedorRequestDto>>(Json);
                return View(proveedor.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public IActionResult Update(int Id, ProveedorRequestDto proveedorDto)
        {
            var httpClient = new HttpClient(ByPassSsl.GetHandler());
            var Token = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            proveedorDto.UpdatedBy = Int32.Parse(HttpContext.Session.GetString("Id"));
            httpClient.BaseAddress = new Uri("https://opencoolmart.somee.com/api/Proveedor/");
            var putTask = httpClient.PutAsJsonAsync<ProveedorRequestDto>("?id=" + Id, proveedorDto);
            putTask.Wait();

            var result = putTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                ViewData["Message"] = "Error";
            }
            else if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(proveedorDto);
        }
    }
}
