using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.DTOs
{
    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string Contrasenia { get; set; }
        public string Correo { get; set; }
        public int PerfilId { get; set; }
    }
}
