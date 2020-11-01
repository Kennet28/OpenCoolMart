using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
namespace OpenCoolMart.Gui.Controllers
{
    public class ProductoController : Controller
    {
        public bool status = true;
        public async Task<IActionResult> Index()
        {
            //https://localhost:44315/api/Producto
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto");
            var ListProductos = JsonConvert.DeserializeObject<List<ProductoResponseDto>>(Json);
            return View(ListProductos);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto/"+Id);
            var producto = JsonConvert.DeserializeObject<ProductoResponseDto>(Json);
            return View(producto);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductoRequestDto requestDto)
        {
            requestDto.Status = true;
            
            var httpClient = new HttpClient();
            var Json = await httpClient.PostAsJsonAsync("https://localhost:44315/api/Producto/",requestDto);
            if (Json.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View(requestDto);
        }

        public async Task<IActionResult> Update(int Id)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto/" + Id);
            var producto = JsonConvert.DeserializeObject<ProductoResponseDto>(Json);
            return View(producto);
        }
        [HttpPost]
        public IActionResult Update(ProductoResponseDto productoDto)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44315/api/Producto/");

            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<ProductoResponseDto>("?id="+productoDto.Id, productoDto);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View(productoDto);
        }
    }
}
