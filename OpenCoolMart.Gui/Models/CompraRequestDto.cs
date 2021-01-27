using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Models
{
    public class CompraRequestDto
    {
        public int ProveedorId { get; set; }
        public int EmpleadoId { get; set; }
        public double PrecioTotal { get; set; }
        public ICollection<CompraProducto> CompraProductos { get; set; }
        public bool Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
