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
        // public IActionResult Backup()
        // {
        //     return View();
        // }
        //
        // [HttpGet]
        // public async Task<IActionResult> BackupAsync(DateTime now)
        // {
        //     var getTask =  await _client.GetStringAsync("https://localhost:44315/api/settings");
        //     if (Int32.Parse(getTask) > 0) return View("Backup Realizado");
        //     return View("Algo Fallo al realizar el backup");
        // }
    }
}