using System;

namespace OpenCoolMart.Gui.Models
{
    public class ClienteRequestDto
    {
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public long Telefono { get; set; }
        public string RFC { get; set; }
        public string Correo { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
