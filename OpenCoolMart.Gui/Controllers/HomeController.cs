using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Gui.Models;

namespace OpenCoolMart.Gui.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
           
        }
       private readonly HttpClient client = new HttpClient();
        public string url = "https://localhost:44315/api/Usuario";
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(LoginModel login)
        {
            var json = await client.GetStringAsync("https://localhost:44315/api/Usuario/");
            var Usuarios = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(json);
            var _Usuario = Usuarios.Data.FirstOrDefault(e => e.Correo.Equals(login.Email) && e.Contrasenia.Equals(login.Password));
            if (_Usuario != null && _Usuario.PerfilId.Equals(1))
            {
                HttpContext.Session.SetString("Id", _Usuario.Id.ToString());
                return RedirectToAction("Menu");
            }
            else if (_Usuario != null && _Usuario.PerfilId.Equals(2))
            {
                HttpContext.Session.SetString("Id", _Usuario.Id.ToString());
                return RedirectToAction("MenuVendedor");
            }
            else if (_Usuario == null)
            {
                
                login.status = false;
                return View();
            }
            return View();
        }
        public IActionResult Menu()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult MenuVendedor()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Id");
            return RedirectToAction("Index");
        }
    }
}
