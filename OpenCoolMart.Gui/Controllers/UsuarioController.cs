using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var json = await client.GetStringAsync(url);
            var Usuarios = JsonConvert.DeserializeObject<List<UsuarioResponseDto>>(json);
            return View(Usuarios);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var json = await client.GetStringAsync(url);
            var Usuarios = JsonConvert.DeserializeObject<List<UsuarioResponseDto>>(json);
            var _Usuario = Usuarios.FirstOrDefault(e => e.Id.Equals(id));
            return View(_Usuario);
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
