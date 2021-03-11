using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Gui.Handler;
using OpenCoolMart.Gui.Models;
using UsuarioResponseDto = OpenCoolMart.Gui.Models.UsuarioResponseDto;

namespace OpenCoolMart.Gui.Controllers
{

    public class HomeController : Controller
    {
        // "https://localhost:44315/api/Usuario";
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel login)
        {
                

            var httpClient = new HttpClient(ByPassSsl.GetHandler());
            var json = await httpClient.PostAsJsonAsync("https://localhost:44315/api/Usuario/Autenticar", login);
            if (json.IsSuccessStatusCode)
            {
                var response = json.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<dynamic>(response.Result);
                string Token = user.Value<string>("token");
                string Id = user.Value<string>("id");
                string Perfil= user.Value<string>("perfil");
                HttpContext.Session.SetString("Id", Id);
                HttpContext.Session.SetString("Token", Token);
                HttpContext.Session.SetString("Perfil", Perfil);
                if (Perfil == "1")
                    return RedirectToAction("Menu");
                else if(Perfil=="2")
                    return RedirectToAction("MenuVendedor");
            }
            return View();
        }
        public IActionResult Menu()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                return View();
            }
            else if(HttpContext.Session.GetString("Perfil") == "2")
            {
                return RedirectToAction("MenuVendedor");
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
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("Perfil");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AsyncToken()
        {
            var Token = HttpContext.Session.GetString("Token");
            await Task.Delay(10);
            return new JsonResult(Token);
        }
    }
}
