using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.Entities
{
   public class Cliente:BaseEntity
   {
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public long Telefono { get; set; }
        public string RFC { get; set; }
        public string Correo { get; set; }
    }
}
