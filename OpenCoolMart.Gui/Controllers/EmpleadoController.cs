using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Controllers
{
    public class EmpleadoController:Controller
    {
        HttpClient client = new HttpClient();
        string url = "https://localhost:44315/api/Empleado";
        public async Task<IActionResult> Index()
        {
            var json = await client.GetStringAsync(url);
            var Empleados = JsonConvert.DeserializeObject<IList<EmpleadoResponseDto>>(json);
            return View(Empleados);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmpleadoUsuarioModel empleadousr)
        {
            var Json2 = await client.PostAsJsonAsync("https://localhost:44315/api/usuario/", empleadousr.Usuario);
            var user = await client.GetStringAsync("https://localhost:44315/api/usuario/");
            var users = JsonConvert.DeserializeObject<IList<UsuarioResponseDto>>(user);
            empleadousr.Empleado.UsuarioId = users.Last().Id;
            empleadousr.Empleado.FechaContratacion = DateTime.Now;
            var Json = await client.PostAsJsonAsync(url, empleadousr.Empleado);
            if (Json.IsSuccessStatusCode && Json2.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(empleadousr);
        }
        public async Task<IActionResult> Details(int id)
        {
            var json = await client.GetStringAsync(url);
            var Empleados = JsonConvert.DeserializeObject<List<EmpleadoResponseDto>>(json);
            var _Empleado = Empleados.FirstOrDefault(e => e.Id.Equals(id));
            return View(_Empleado);
        }
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var json = await client.GetStringAsync(url);
            var Empleados = JsonConvert.DeserializeObject<List<EmpleadoResponseDto>>(json);
            var _Empleado = Empleados.FirstOrDefault(e => e.Id.Equals(id));
            return View(_Empleado);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(EmpleadoResponseDto empleadoDto)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44315/api/empleado/");
            var putTask = await httpClient.PutAsJsonAsync("?id=" + empleadoDto.Id, empleadoDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(empleadoDto);
        }
    }
}
