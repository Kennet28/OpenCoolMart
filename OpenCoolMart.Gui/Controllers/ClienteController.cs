﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OpenCoolMart.Gui.Handler;
using ClienteRequestDto = OpenCoolMart.Gui.Models.ClienteRequestDto;
using ClienteResponseDto = OpenCoolMart.Gui.Models.ClienteResponseDto;

namespace OpenCoolMart.Gui.Controllers
{
    public class ClienteController : Controller
    {
        HttpClient client = new HttpClient(ByPassSsl.GetHandler());
        string url = "https://localhost:44315/api/cliente/";

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync(url);
                var Clientes = JsonConvert.DeserializeObject<ApiResponse<List<ClienteResponseDto>>>(json);
                return View(Clientes.Data);
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
        public async Task<IActionResult> Create(ClienteRequestDto Cliente)
        {
            Cliente.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var Token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var Json = await client.PostAsJsonAsync("https://localhost:44315/api/Cliente/", Cliente);
            if (Json.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(Cliente);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync("https://localhost:44315/api/cliente/" + id);
                var _Cliente = JsonConvert.DeserializeObject<ApiResponse<ClienteResponseDto>>(json);
                return View(_Cliente.Data);
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
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync("https://localhost:44315/api/cliente/" + id);
                var _Cliente = JsonConvert.DeserializeObject<ApiResponse<ClienteRequestDto>>(json);
                return View(_Cliente.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, ClienteRequestDto ClienteDto)
        {
            var Token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.BaseAddress = new Uri("https://localhost:44315/api/Cliente/");
            ClienteDto.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var putTask = await client.PutAsJsonAsync("?id=" + id, ClienteDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(ClienteDto);
        }
    }
}
