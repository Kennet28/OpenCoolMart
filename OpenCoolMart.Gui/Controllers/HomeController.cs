using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Gui.Models;
using Microsoft.AspNetCore.Session;

namespace OpenCoolMart.Gui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        HttpClient client = new HttpClient();
        string url = "https://localhost:44315/api/Usuarios";
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(LoginModel login)
        {
            var json = await client.GetStringAsync(url);
            var Usuarios = JsonConvert.DeserializeObject<List<UsuarioResponseDto>>(json);
            var _Usuario = Usuarios.FirstOrDefault(e => e.Correo.Equals(login.Email) && e.Contrasenia.Equals(login.Password));
            if (!_Usuario.Equals(null) && _Usuario.PerfilId.Equals(1))
            {
                //Session["User"] = _Usuario;
                return RedirectToAction("Menu");
            }
            else if (!_Usuario.Equals(null) && _Usuario.PerfilId.Equals(2))
            {
                return RedirectToAction("MenuVendedor");
            }
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }

    }
}
