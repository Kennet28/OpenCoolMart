using System;

namespace OpenCoolMart.Gui.Models
{
    public class CajaResponseDto
    {
        public int Id { get; set; }
        public double CantidadDiaria { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public double CantidadTotal { get; set; }
        public double MontoRetirado { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
