using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCoolMart.Domain.Entities
{
    public class Perfil
    {
        public int PerfilId { get; set; }
        public string Cargo { get; set; }
        [ForeignKey("PermisoId")]
        public int PermisoId { get; set; }
    }
}
