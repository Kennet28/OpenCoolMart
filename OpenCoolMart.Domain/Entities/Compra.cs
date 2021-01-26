using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCoolMart.Domain.Entities
{
    public class Compra:BaseEntity
    {
        [ForeignKey("Proveedor")]
        public int ProveedorId { get; set; }
        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }
        public double PrecioTotal { get; set; }

        public ICollection<CompraProducto> CompraProductos { get; set; }
        public Proveedor Proveedor { get; set; }
        public Empleado Empleado { get; set; }
       
    }
}
