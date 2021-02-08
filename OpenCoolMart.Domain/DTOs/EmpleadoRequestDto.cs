using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.DTOs
{
    public class EmpleadoRequestDto
    {
        public string Nombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        public long Telefono { get; set; }
        public int UsuarioId { get; set; }
        public int CodigoEmpleado { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
