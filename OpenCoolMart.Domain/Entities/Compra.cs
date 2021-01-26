using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCoolMart.Domain.Entities
{
    public class Compra:BaseEntity
    {
        [ForeignKey("Proveedor")]
        public int ProveedorId { get; set; }
        public double PrecioTotal { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
