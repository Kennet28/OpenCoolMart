using System;
using System.Collections.Generic;


namespace OpenCoolMart.Domain.Entities
{
    public class Producto:BaseEntity
    {
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Marca { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public int Stock { get; set; }
        public int CodigoProducto { get; set; }

        public IEnumerable<DetallesVenta> DetallesVentas { get; set; }
    }
}
