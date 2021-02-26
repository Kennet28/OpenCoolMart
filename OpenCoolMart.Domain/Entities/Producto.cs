using System.Collections.Generic;


namespace OpenCoolMart.Domain.Entities
{
    public class Producto:BaseEntity
    {
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioCompra { get; set; }
        public string Marca { get; set; }
        public string Clasificacion { get; set; }
        public int Stock { get; set; }
        public int CodigoProducto { get; set; }
        public double? Descuento { get; set; }
        public string Imagen { get; set; }

        public IEnumerable<DetallesVenta> DetallesVentas { get; set; }
        public ICollection<CompraProducto> CompraProductos { get; set; }
    }
}
