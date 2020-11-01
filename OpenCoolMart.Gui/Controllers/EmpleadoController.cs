using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Controllers
{
    public class EmpleadoController:Controller
    {
        HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            string url = "https://localhost:44315/api/Empleado";
            var json = await client.GetStringAsync(url);
            var Empleados = JsonConvert.DeserializeObject<IList<EmpleadoResponseDto>>(json);
            return View(Empleados);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            string url = $"https://localhost:44315/api/Empleado";
            var json = await client.GetStringAsync(url);
            var Empleados = JsonConvert.DeserializeObject<List<EmpleadoResponseDto>>(json);
            var _Empleado = Empleados.FirstOrDefault(e => e.Id.Equals(id));
            return View(_Empleado);
        }
        public IActionResult Update(/*int id*/)
        {

            return View();
        }
    }
}
