using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UsuarioResponseDto = OpenCoolMart.Gui.Models.UsuarioResponseDto;

namespace OpenCoolMart.Gui.Controllers
{
    public class UsuarioController : Controller
    {
        HttpClient client = new HttpClient();
        //string url = "https://localhost:44315/api/Usuario";
        public async Task<IActionResult> Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync("https://localhost:44315/api/Usuario/");
                var usuarios = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(json);
                return View(usuarios.Data);
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
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync("https://localhost:44315/api/Usuario/"+id);
                var usuario = JsonConvert.DeserializeObject<ApiResponse<UsuarioResponseDto>>(json);
                return View(usuario.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var Token = HttpContext.Session.GetString("Token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await client.GetStringAsync("https://localhost:44315/api/Usuario/"+id);
                var usuario = JsonConvert.DeserializeObject<ApiResponse<UsuarioResponseDto>>(json);
                return View(usuario.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Update(int id,UsuarioResponseDto usuarioDto)
        {
            var Token = HttpContext.Session.GetString("Token");
            
            var httpClient = new HttpClient {
                BaseAddress = new Uri("https://localhost:44315/api/Usuario/")
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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
