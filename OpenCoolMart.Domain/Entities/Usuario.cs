using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenCoolMart.Domain.Entities
{
    public class Usuario:BaseEntity
    {
        public string Contrasenia { get; set; }
        public string Correo { get; set; }
        [ForeignKey("Pefil")]
        public int PerfilId { get; set; }
        public string Token { get; set; }
        public Perfil Perfil { get; set; }
    }
}