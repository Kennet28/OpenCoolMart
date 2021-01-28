﻿using System;
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
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            var json = await client.GetStringAsync("https://localhost:44315/api/settings");
            var settings = JsonConvert.DeserializeObject<ApiResponse<SettingsResponseDto>>(json);
            return View(settings.Data);
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(SettingsResponseDto setting)
        {
            // client.BaseAddress = new Uri("");
            var json = await client.PutAsJsonAsync("https://localhost:44315/api/settings",setting);
            return RedirectToAction("Index");;
        }
    }
}