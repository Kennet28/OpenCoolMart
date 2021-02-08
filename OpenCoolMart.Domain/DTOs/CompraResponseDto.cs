using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OpenCoolMart.Domain.DTOs
{
    public class CompraResponseDto
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int EmpleadoId { get; set; }
        public double PrecioTotal { get; set; }
        public ICollection<CompraProducto> CompraProductos { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
        public ProveedorResponseDto Proveedor { get; set; }
    }
}
