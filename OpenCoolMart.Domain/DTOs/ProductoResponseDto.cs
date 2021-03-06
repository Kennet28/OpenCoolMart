﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.DTOs
{
    public class ProductoResponseDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioCompra { get; set; }
        public string Marca { get; set; }
        public string Clasificacion { get; set; }
        public int Stock { get; set; }
        public int CodigoProducto { get; set; }
        public double? Descuento { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string Imagen { get; set; }
    }
}
