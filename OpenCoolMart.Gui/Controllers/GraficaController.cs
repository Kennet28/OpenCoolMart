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

namespace OpenCoolMart.Gui.Controllers
{
    public class GraficaController : Controller
    {
        public bool status = true;
        private readonly IMapper _mapper;
        public GraficaController(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")) && HttpContext.Session.GetString("Perfil") == "1")
            {
                ViewBag.Meses = GetMeses();
                return View();
            }
            
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public List<SelectListItem> GetMeses()
        {
            List<SelectListItem> Meses = Enum.GetValues(typeof(meses)).Cast<meses>().ToList().ConvertAll(P =>
            {
                
                return new SelectListItem()
                {
                    
                    Text = P.ToString(),
                    Value = ((int)P).ToString(),
                    Selected = false
                };
            });
            return Meses;
        }
    }
}
