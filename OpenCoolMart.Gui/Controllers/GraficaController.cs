using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenCoolMart.Gui.Enumerations;
using Wkhtmltopdf.NetCore;

namespace OpenCoolMart.Gui.Controllers
{
    public class GraficaController : Controller
    {
        public bool status = true;
        private readonly IMapper _mapper;
        private readonly IGeneratePdf _generatePdf;

        public GraficaController(IMapper mapper,IGeneratePdf generatePdf)
        {
            this._mapper = mapper;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                return View();
            }
            
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
