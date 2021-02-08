using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCoolMart.Domain.Entities
{
    public class CompraProducto
    {
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        [ForeignKey("Compra")]
        public int CompraId { get; set; }

        public int CantidadProducto { get; set; }
        public double TotalPorProducto { get; set; }

        public Producto Producto { get; set; }
    }
}
