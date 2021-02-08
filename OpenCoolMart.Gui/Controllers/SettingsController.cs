using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Gui.Models;
namespace OpenCoolMart.Gui.Controllers
{
    public class SettingsController : Controller
    {
        private readonly HttpClient _client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            var json = await _client.GetStringAsync("https://localhost:44315/api/settings");
            var settings = JsonConvert.DeserializeObject<ApiResponse<SettingsResponseDto>>(json);
            return View(settings.Data);
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(SettingsResponseDto setting)
        {
            // client.BaseAddress = new Uri("");
            var json = await _client.PutAsJsonAsync("https://localhost:44315/api/settings",setting);
            return RedirectToAction("Index");;
        }
<<<<<<< HEAD
=======
        [HttpGet]
        public async Task<IActionResult> Respaldar()
        {
            await _client.GetStringAsync("https://localhost:44315/api/settings/backup");
            return RedirectToAction("Index");
        }
>>>>>>> a3a3ce209b3e29b1e3e25d655ef2dbd98679b5b3
    }
}