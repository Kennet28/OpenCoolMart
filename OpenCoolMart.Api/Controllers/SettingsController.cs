using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System.Threading.Tasks;

namespace OpenCoolMart.Api.Controllers
{
    [AllowAnonymous]
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
        [Route("backup")]
        public async Task<IActionResult> BackUp()
        {
            await _settingsService.BackUp();
            return Ok();
        }
    }
}