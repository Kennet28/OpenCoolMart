<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
>>>>>>> a3a3ce209b3e29b1e3e25d655ef2dbd98679b5b3
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
<<<<<<< HEAD
=======
        [Route("backup")]
        public async Task<IActionResult> BackUp()
        {
            await _settingsService.BackUp();
            return Ok();
        }
>>>>>>> a3a3ce209b3e29b1e3e25d655ef2dbd98679b5b3
    }
}