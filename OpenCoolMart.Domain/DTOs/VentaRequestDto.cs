﻿using OpenCoolMart.Domain.Entities;
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
        public ICollection<DetallesVenta> DetallesVentas { get; set; }
    }
}
