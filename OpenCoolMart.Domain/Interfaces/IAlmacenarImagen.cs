using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IAlmacenarImagen
    {
        Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta,string contentType);
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> GuardarArchivo(byte[] contenido, string extension, string contenedor, string contentType);
    }
}
