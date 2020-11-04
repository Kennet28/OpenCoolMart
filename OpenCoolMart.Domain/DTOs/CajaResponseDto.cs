using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.DTOs
{
    public class CajaResponseDto
    {
        public int Id { get; set; }
        public double CantidadDiaria { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public double CantidadTotal { get; set; }
        public double MontoRetirado { get; set; }

    }
}
