using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OpenCoolMart.Api.Responses;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Gui.Models;
using OpenCoolMart.Gui.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace OpenCoolMart.Gui.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly HttpClient  client = new HttpClient();
        readonly string url = "https://localhost:44315/api/Empleado/";
        public async Task<IActionResult> Index()
        {


            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Empleados = JsonConvert.DeserializeObject<ApiResponse<List<EmpleadoResponseDto>>>(json);
                return View(Empleados.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                ViewBag.Perfiles = GetPerfiles();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmpleadoUsuarioModel empleadousr)
        {
            empleadousr.Usuario.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            UsuarioRequestDto usuarioRequestDto = empleadousr.Usuario;
            var Json2 = await client.PostAsJsonAsync("https://localhost:44315/api/usuario/", usuarioRequestDto);
            var user = await client.GetStringAsync("https://localhost:44315/api/usuario/");
            var users = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(user);
            if (Json2.IsSuccessStatusCode)
            {
                empleadousr.Empleado.UsuarioId = users.Data.Last().Id;
                empleadousr.Empleado.FechaContratacion = DateTime.Now;
                empleadousr.Empleado.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
                EmpleadoRequestDto empleadoRequestDto = empleadousr.Empleado;
                var Json = await client.PostAsJsonAsync("https://localhost:44315/api/empleado/", empleadoRequestDto);
                if (Json.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Perfiles = GetPerfiles();
                    ViewData["Error"] = "Empleado no registrado";
                    return View(empleadousr);

                }
            }
            else
            {
                ViewBag.Perfiles = GetPerfiles();
                ViewData["Error"] = "Usuario no creado";
                return View(empleadousr);

            }

        }
        public async Task<IActionResult> Details(int id)
        {

            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44315/api/Empleado/" + id);
                var _Empleado = JsonConvert.DeserializeObject<ApiResponse<EmpleadoResponseDto>>(json);
                return View(_Empleado.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public async Task<IActionResult> Update(int id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44315/api/Empleado/"+id);
                var _Empleado = JsonConvert.DeserializeObject<ApiResponse<EmpleadoRequestDto>>(json);
                return View(_Empleado.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id, EmpleadoRequestDto empleadoDto)
        {
            empleadoDto.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            var putTask = await client.PutAsJsonAsync("https://localhost:44315/api/empleado/?id=" + Id, empleadoDto);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(empleadoDto);
        }
        public List<SelectListItem> GetPerfiles()
        {
            List<SelectListItem> perfiles = Enum.GetValues(typeof(Perfiles)).Cast<Perfiles>().ToList().ConvertAll(P =>
            {
                
                return new SelectListItem()
                {
                    
                    Text = P.ToString(),
                    Value = ((int)P).ToString(),
                    Selected = false
                };
            });
            return perfiles;
        }
    }
}
