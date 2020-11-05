using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Models
{
    public class VentaRequestDto
    {
        public double VentaTotal { get; set; }
        public double SubTotal { get; set; }
        public double Efectivo { get; set; }
        public double Cambio { get; set; }
        public double Iva { get; set; }
        public string FormaPago { get; set; }
        public DateTime FechaVenta { get; set; }
        public int EmpleadoId { get; set; }
        public int CajaId { get; set; }
        public ICollection<DetallesVenta> DetallesVentas { get; set; }
    }
}
