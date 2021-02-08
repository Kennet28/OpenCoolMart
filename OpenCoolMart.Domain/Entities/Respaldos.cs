using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCoolMart.Domain.Entities
{
    public class Respaldos:BaseEntity
    {
        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }
        public string Ruta { get; set; }
    }
}