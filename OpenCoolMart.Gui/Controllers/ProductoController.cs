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
namespace OpenCoolMart.Gui.Controllers
{
    public class ProductoController : Controller
    {
        public bool status = true;
        public async Task<IActionResult> Index()
        {
            //https://localhost:44315/api/Producto

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var httpClient = new HttpClient();
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer",Token);
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto");
                var ListProductos = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProductoResponseDto>>>(Json);
                return View(ListProductos.Data);
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
                var httpClient = new HttpClient();
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto/" + Id);
                var producto = JsonConvert.DeserializeObject<ApiResponse<ProductoResponseDto>>(Json);
                return View(producto.Data);
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
        public async Task<IActionResult> Create(ProductoRequestDto requestDto)
        {
            requestDto.CreatedBy = Int32.Parse(HttpContext.Session.GetString("Id"));

            requestDto.PrecioCompra = 1;
            var httpClient = new HttpClient();
            var Token = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var Json = await httpClient.PostAsJsonAsync("https://localhost:44315/api/Producto/", requestDto);
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
                var httpClient = new HttpClient();
                var Token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var Json = await httpClient.GetStringAsync("https://localhost:44315/api/Producto/" + Id);
                var producto = JsonConvert.DeserializeObject<ApiResponse<ProductoRequestDto>>(Json);
                return View(producto.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public IActionResult Update(int Id, ProductoRequestDto productoDto)
        {
            productoDto.PrecioCompra = 1;

            var httpClient = new HttpClient();
            var Token = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            productoDto.UpdatedBy = Int32.Parse(HttpContext.Session.GetString("Id"));
            httpClient.BaseAddress = new Uri("https://localhost:44315/api/Producto/");
            var content = ConvertToFormData(productoDto);
            var putTask = httpClient.PutAsync("?id=" + Id, content);
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
            return View(productoDto);
        }  
        
        public MultipartFormDataContent ConvertToFormData(ProductoRequestDto producto)
        {
            var content = new MultipartFormDataContent();

            /*
             content.Add(new StringContent("Clasificacion"), producto.Clasificacion);
             content.Add(new StringContent("CodigoProducto"), producto.CodigoProducto.ToString());
             content.Add(new StringContent("CreatedBy"),producto.CreatedBy.ToString() );
             content.Add(new StringContent("Descripcion"),producto.Descripcion );
             content.Add(new StringContent("Descuento"),producto.Descuento.ToString() );
             content.Add(new StringContent("Marca"),producto.Marca );
             content.Add(new StringContent("PrecioCompra"),producto.PrecioCompra.ToString() );
             content.Add(new StringContent("PrecioVenta"),producto.PrecioVenta.ToString());
             content.Add(new StringContent("Status"),producto.Status.ToString() );
             content.Add(new StringContent("Stock"),producto.Stock.ToString() );
             content.Add(new StringContent("UpdatedBy"),producto.UpdatedBy.ToString() );
             */

            content.Add(new StringContent(producto.Clasificacion), "Clasificacion");
            content.Add(new StringContent(producto.CodigoProducto.ToString()), "CodigoProducto");
            content.Add(new StringContent(producto.CreatedBy.ToString()), "CreatedBy");
            content.Add(new StringContent(producto.Descripcion), "Descripcion");
            content.Add(new StringContent(producto.Descuento.ToString()), "Descuento");
            content.Add(new StringContent(producto.Marca), "Marca");
            content.Add(new StringContent(producto.PrecioCompra.ToString()), "PrecioCompra");
            content.Add(new StringContent(producto.PrecioVenta.ToString()), "PrecioVenta");
            content.Add(new StringContent(producto.Status.ToString()), "Status");
            content.Add(new StringContent(producto.Stock.ToString()), "Stock");
            content.Add(new StringContent(producto.UpdatedBy.ToString()), "UpdatedBy");
            
            /*if (producto.Imagen != null)
                content.Add(new StringContent(producto.Imagen.ContentType), "Imagen");
            else
                content.Add(producto.Imagen, "file", producto.Imagen.FileName);*/
            return content;
        }
    }
}
