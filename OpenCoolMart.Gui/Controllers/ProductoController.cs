using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System;
using System.Collections.Generic;
using System.IO;
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
            var content = await ConvertToFormDataAsync(requestDto);
            var Json = await httpClient.PostAsync("https://localhost:44315/api/Producto/", content);
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
                var producto = JsonConvert.DeserializeObject<ApiResponse<ProductoResponseDto>>(Json);
                return View(producto.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(int Id, ProductoRequestDto productoDto)
        {
            productoDto.PrecioCompra = 1;

            var httpClient = new HttpClient();
            var Token = HttpContext.Session.GetString("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            productoDto.UpdatedBy = Int32.Parse(HttpContext.Session.GetString("Id"));
            httpClient.BaseAddress = new Uri("https://localhost:44315/api/Producto/");
            var content = await ConvertToFormDataAsync(productoDto);
            var putTask = await httpClient.PutAsync("?id=" + Id, content);
            
            if (!putTask.IsSuccessStatusCode)
            {
                ViewData["Message"] = "Error";                
            }
            else if (putTask.IsSuccessStatusCode)
            {                
                return RedirectToAction("Index");
            }
            return View(productoDto);
        }  
        
        public async Task<MultipartFormDataContent> ConvertToFormDataAsync(ProductoRequestDto producto)
        {
            var content = new MultipartFormDataContent();
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
            if (producto.Imagen != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await producto.Imagen.CopyToAsync(memoryStream);

                    var contenido = memoryStream.ToArray();
                    var bytes = new ByteArrayContent(contenido);
                    bytes.Headers.ContentType = MediaTypeHeaderValue.Parse(producto.Imagen.ContentType);
                    //contenido. = producto.Imagen.ContentType;
                    content.Add(bytes, "Imagen",producto.Imagen.FileName);
                }
            }                
            return content;
        }
    }
}
