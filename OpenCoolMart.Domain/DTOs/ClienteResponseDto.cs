using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Domain.DTOs
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public long Telefono { get; set; }
        public string RFC { get; set; }
        public string Correo { get; set; }

    }
}
