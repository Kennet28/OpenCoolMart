using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.Entities
{
    public class Facturas:BaseEntity
    {
        public int Folio { get; set; }
        public Cliente Cliente { get; set; }
        public string UsoCFDI { get; set; }
        public string Observaciones { get; set; }
        public Venta Venta { get; set; }
        public DateTime Fecha { get; set; }
    }
}
