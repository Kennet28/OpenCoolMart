using System;
using System.Collections.Generic;

namespace OpenCoolMart.Domain.Entities
{
    public class Venta:BaseEntity
    {
        public double VentaTotal { get; set; }
        public double SubTotal { get; set; }
        public double Efectivo { get; set; }
        public double Cambio { get; set; }
        public double Iva { get; set; }
        public string FormaPago { get; set; }
        public DateTime FechaVenta { get; set; }

        public IEnumerable<DetallesVenta> DetallesVentas { get; set; }
    }
}
