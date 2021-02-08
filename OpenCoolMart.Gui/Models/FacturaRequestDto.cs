﻿using System;

namespace OpenCoolMart.Gui.Models
{
    public class FacturaRequestDto
    {
        public int Folio { get; set; }
        public int ClienteId { get; set; }
        public string UsoCFDI { get; set; }
        public string Observaciones { get; set; }
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
