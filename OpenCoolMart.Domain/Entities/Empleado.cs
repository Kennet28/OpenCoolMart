using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCoolMart.Domain.Entities
{
    public class Empleado:BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        public long Telefono { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public int CodigoEmpleado { get; set; }
    }
}
