using OpenCoolMart.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Models
{
    public class EmpleadoUsuarioModel
    {
        public EmpleadoRequestDto Empleado {get;set;}
        public UsuarioRequestDto Usuario {get;set; }
    }
}
