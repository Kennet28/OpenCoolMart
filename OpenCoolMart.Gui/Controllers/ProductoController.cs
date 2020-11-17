using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
<<<<<<< HEAD

=======
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
>>>>>>> 219c194347e2674694a45b8e46c8ca18c23ba6b0
namespace OpenCoolMart.Gui.Controllers
{
    public class ProductoController : Controller
    {
        public bool status = true;
        public async Task<IActionResult> Index()
        {
            //https://localhost:44315/api/Producto
<<<<<<< HEAD
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto");
            var ListProductos = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProductoResponseDto>>>(Json);
            return View(ListProductos.Data);
=======

            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto");
                var ListProductos = JsonConvert.DeserializeObject<List<ProductoResponseDto>>(Json);
                return View(ListProductos);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
>>>>>>> 219c194347e2674694a45b8e46c8ca18c23ba6b0
        }

        public async Task<IActionResult> Details(int Id)
        {
<<<<<<< HEAD
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto/"+Id);
            var producto = JsonConvert.DeserializeObject<ApiResponse<ProductoResponseDto>>(Json);
            return View(producto.Data);
=======
            if (HttpContext.Session.GetString("Id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto/" + Id);
                var producto = JsonConvert.DeserializeObject<ProductoResponseDto>(Json);
                return View(producto);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
>>>>>>> 219c194347e2674694a45b8e46c8ca18c23ba6b0
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
        public async Task<IActionResult> Create(ProductoRequestDto requestDto)
        {
            var httpClient = new HttpClient();
            var Json = await httpClient.PostAsJsonAsync("https://localhost:44315/api/Producto/", requestDto);
            if (Json.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View(requestDto);
        }

        public async Task<IActionResult> Update(int Id)
        {
<<<<<<< HEAD
            var httpClient = new HttpClient();
            var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto/" + Id);
            var producto = JsonConvert.DeserializeObject<ApiResponse<ProductoRequestDto>>(Json);
            return View(producto.Data);
=======
            if (HttpContext.Session.GetString("Id") != null)
            {

                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto/" + Id);
                var producto = JsonConvert.DeserializeObject<ProductoRequestDto>(Json);
                return View(producto);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
>>>>>>> 219c194347e2674694a45b8e46c8ca18c23ba6b0
        }
        [HttpPost]
        public IActionResult Update(int Id, ProductoRequestDto productoDto)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44315/api/Producto/");
            //TODO: obtener id del usuario que inicio sesion con int.Parse(HttpContext.Session.GetString("Id")) e integrar UpdatedBy 
            var putTask = httpClient.PutAsJsonAsync<ProductoRequestDto>("?id=" + Id, productoDto);
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
