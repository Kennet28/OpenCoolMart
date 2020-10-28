using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.Entities
{
    public class Caja:BaseEntity
    {
        public double CantidadDiaria { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public double CantidadTotal { get; set; }
        public double MontoRetirado { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }

    }
}
