using OpenCoolMart.Domain.DTOs;
using System.ComponentModel.DataAnnotations.Schema;


namespace OpenCoolMart.Domain.Entities
{
    public class DetallesVenta
    {
        [ForeignKey("Venta")]
        public int VentaId { get; set; }
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        
        public int CantiProd { get; set; }
        public double VentaProductos { get; set; }

        public Producto Producto { get; set; }

        public Venta Venta { get; set; }
    }
}
