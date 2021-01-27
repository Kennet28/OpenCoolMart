using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Models
{
    public class ProveedorResponseDto
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
