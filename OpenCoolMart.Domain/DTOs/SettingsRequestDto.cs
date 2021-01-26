using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Domain.DTOs
{
    public class SettingsRequestDto
    {
        public int Ncaja { get; set; }
        public string Ip { get; set; }
        public string RutaRespaldo { get; set; }
        public Empleado Empleado { get; set; }
        public string BDConexion { get; set; }
        public string TipoImpuesto { get; set;}
    }
}