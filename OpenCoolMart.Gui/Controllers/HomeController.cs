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
using UsuarioResponseDto = OpenCoolMart.Gui.Models.UsuarioResponseDto;

namespace OpenCoolMart.Gui.Controllers
{
    public class HomeController : Controller
    {
       private readonly HttpClient _client = new HttpClient();
        // "https://localhost:44315/api/Usuario";
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel login)
        {
            var json = await _client.GetStringAsync("https://localhost:44315/api/Usuario/");
            var users = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(json);
            var user = users.Data.FirstOrDefault(e => e.Correo.Equals(login.Email) && e.Contrasenia.Equals(login.Password));
            if (user != null && user.PerfilId.Equals(1))
            {
                HttpContext.Session.SetString("Id", user.Id.ToString());
                return RedirectToAction("Menu");
            }
            else if (user != null && user.PerfilId.Equals(2))
            {
                HttpContext.Session.SetString("Id", user.Id.ToString());
                return RedirectToAction("MenuVendedor");
            }
            else if (user == null)
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
