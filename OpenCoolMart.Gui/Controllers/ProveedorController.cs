using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Controllers
{
    public class ProveedorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Proveedor");
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
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Proveedor/" + Id);
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
        public async Task<IActionResult> Create(ProveedorRequestDto requestDto)
        {
            requestDto.CreatedBy = Int32.Parse(HttpContext.Session.GetString("Id"));

            var httpClient = new HttpClient();
            var Json = await httpClient.PostAsJsonAsync("https://localhost:44315/api/Proveedor/", requestDto);
            if (Json.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View(requestDto);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Proveedor/" + Id);
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
            var httpClient = new HttpClient();
            proveedorDto.UpdatedBy = Int32.Parse(HttpContext.Session.GetString("Id"));
            httpClient.BaseAddress = new Uri("https://localhost:44315/api/Proveedor/");
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
