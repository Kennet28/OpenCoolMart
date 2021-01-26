using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.DTOs
{
    public class ProveedorRequestDto
    {
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public bool Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
