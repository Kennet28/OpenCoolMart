using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenCoolMart.Domain.Entities
{
    public class Facturas:BaseEntity
    {
        public int Folio { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public string UsoCFDI { get; set; }
        public string Observaciones { get; set; }
        [ForeignKey("Cliente")]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
