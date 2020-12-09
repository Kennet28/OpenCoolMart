using System;

namespace OpenCoolMart.Gui.Models
{
    public class EmpleadoResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Telefono { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int UsuarioId { get; set; }
        public int CodigoEmpleado { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
