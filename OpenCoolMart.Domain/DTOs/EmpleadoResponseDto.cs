using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.DTOs
{
    public class EmpleadoResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int UsuarioId { get; set; }
        public int CodigoEmpleado { get; set; }
    }
}
