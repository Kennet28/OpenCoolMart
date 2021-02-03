using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Application.Services;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;

namespace OpenCoolMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var settings = _settingsService.GetSettings();
            var response = new ApiResponse<Configuraciones>(settings);
            return Ok(response);
        }
        [HttpPut]
        public IActionResult Put(Configuraciones config)
        {
            _settingsService.UpdateSettings(config);
            var response = new ApiResponse<Configuraciones>(config);
            return Ok(response);
        }
    }
}