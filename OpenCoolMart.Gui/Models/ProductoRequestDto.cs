using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Gui.Models
{
    public class ProductoRequestDto
    {
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Marca { get; set; }
        public string Clasificacion { get; set; }
        public int Stock { get; set; }
        public int CodigoProducto { get; set; }
        public bool Status { get; set; }
    }
}
