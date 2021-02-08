using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.DTOs
{
    public class VentaRequestDto
    {
        public double VentaTotal { get; set; }
        public double SubTotal { get; set; }
        public double Efectivo { get; set; }
        public double Cambio { get; set; }
        public double Iva { get; set; }
        public string FormaPago { get; set; }
        public int EmpleadoId { get; set; }
        public int CajaId { get; set; }
<<<<<<< HEAD
        public int ClienteId { get; set; }
=======
>>>>>>> a3a3ce209b3e29b1e3e25d655ef2dbd98679b5b3
        public ICollection<DetallesVenta> DetallesVentas { get; set; }
    }
}
