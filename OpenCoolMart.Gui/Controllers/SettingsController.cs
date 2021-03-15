using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Gui.Handler;
using OpenCoolMart.Gui.Models;
namespace OpenCoolMart.Gui.Controllers
{
    public class SettingsController : Controller
    {
        private readonly HttpClient _client = new HttpClient(ByPassSsl.GetHandler());
        public async Task<IActionResult> Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                var Token = HttpContext.Session.GetString("Token");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await _client.GetStringAsync("https://opencoolmart.somee.com/api/settings");
                var settings = JsonConvert.DeserializeObject<ApiResponse<SettingsResponseDto>>(json);
                return View(settings.Data);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(SettingsResponseDto setting)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) &&
                HttpContext.Session.GetString("Perfil") == "1")
            {
                var Token = HttpContext.Session.GetString("Token");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var json = await _client.PutAsJsonAsync("https://opencoolmart.somee.com/api/settings/update/", setting);
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Menu","Home");
            }
        }

    }
}