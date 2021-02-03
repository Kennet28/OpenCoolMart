using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCoolMart.Domain.Entities
{
    public class Venta:BaseEntity
    {
        public double VentaTotal { get; set; }
        public double SubTotal { get; set; }
        public double Efectivo { get; set; }
        public double Cambio { get; set; }
        public double Iva { get; set; }
        public int Folio { get; set; }
        public string FormaPago { get; set; }
        public DateTime FechaVenta { get; set; }
        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }
        public int CajaId { get; set; }

        public ICollection<DetallesVenta> DetallesVentas { get; set; }
        public Empleado Empleado { get; set; }
        //public Caja Caja { get; set; }
        // public virtual ICollection<Facturas> Factura { get; set; }

    }
}
