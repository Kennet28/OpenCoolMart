using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Domain.DTOs;

namespace OpenCoolMart.Gui.Controllers
{
    public class ClienteController : Controller
    {

        HttpClient client = new HttpClient();
        string url = "https://localhost:44315/api/cliente/";
        public async Task<IActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Clientes = JsonConvert.DeserializeObject<IList<ClienteResponseDto>>(json);
                return View(Clientes);
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
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Clientes = JsonConvert.DeserializeObject<List<ClienteResponseDto>>(json);
                var _Cliente = Clientes.FirstOrDefault(e => e.Id.Equals(id));
                return View(_Cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> UpdateAsync(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Clientes = JsonConvert.DeserializeObject<List<ClienteResponseDto>>(json);
                var _Cliente = Clientes.FirstOrDefault(e => e.Id.Equals(id));
                return View(_Cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ClienteResponseDto ClienteDto)
        {
            client.BaseAddress = new Uri("https://localhost:44315/api/Cliente/");
            ClienteDto.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var putTask = await client.PutAsJsonAsync("?id=" + ClienteDto.Id, ClienteDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(ClienteDto);
        }
    }
}
