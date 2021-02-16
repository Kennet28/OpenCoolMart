﻿using Microsoft.AspNetCore.Http;
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
            var putTask = httpClient.PutAsJsonAsync<ProductoRequestDto>("?id=" + Id, productoDto);
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
    }
}
