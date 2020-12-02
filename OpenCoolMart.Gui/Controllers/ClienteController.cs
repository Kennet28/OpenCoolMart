using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;

namespace OpenCoolMart.Gui.Controllers
{
    public class ClienteController : Controller
    {
        protected IJSRuntime Js { get; set; }

        HttpClient client = new HttpClient();
        string url = "https://localhost:44315/api/cliente/";
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
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
            client.BaseAddress = new Uri("https://localhost:44315/api/Cliente/");
            ClienteDto.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var putTask = await client.PutAsJsonAsync("?id=" + id, ClienteDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(ClienteDto);
        }
        //[JSInvokable]
        //public async Task<IActionResult> Buscar(string nombre)
        //{

        //    var json = await client.GetStringAsync("https://localhost:44315/api/Cliente/");
        //    var Clientes = JsonConvert.DeserializeObject<ApiResponse<List<ClienteResponseDto>>>(json);
        //    var cliente = Clientes.Data.FirstOrDefault(clt => clt.Nombre.Contains(nombre));
        //    return View(cliente);
        //}
        //protected async Task BuscarJavaScript()
        //{
        //    await Js.InvokeVoidAsync("");
        //}
    }
}
