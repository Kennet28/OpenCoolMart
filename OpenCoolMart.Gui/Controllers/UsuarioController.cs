using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Controllers
{
    public class UsuarioController : Controller
    {
        HttpClient client = new HttpClient();
        string url = "https://localhost:44315/api/Usuario";
        public async Task<IActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44315/api/Usuario/");
                var Usuarios = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(json);
                return View(Usuarios.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44315/api/Usuario/"+id);
                var _Usuario = JsonConvert.DeserializeObject<ApiResponse<UsuarioResponseDto>>(json);
                return View(_Usuario.Data);
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
                var json = await client.GetStringAsync("https://localhost:44315/api/Usuario/"+id);
                var _Usuario = JsonConvert.DeserializeObject<ApiResponse<UsuarioResponseDto>>(json);
                return View(_Usuario.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Update(int id,UsuarioResponseDto usuarioDto)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44315/api/Usuario/");
            var putTask = httpClient.PutAsJsonAsync("?id=" + id, usuarioDto);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View(usuarioDto);
        }
    }
}
