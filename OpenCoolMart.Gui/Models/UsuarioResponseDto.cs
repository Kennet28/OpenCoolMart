using System;

namespace OpenCoolMart.Gui.Models
{
    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string Contrasenia { get; set; }
        public string Correo { get; set; }
        public int PerfilId { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
