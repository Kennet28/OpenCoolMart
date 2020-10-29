using OpenCoolMart.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task AddUsuario(Usuario producto);
        Task DeleteUsuario(int id);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task UpdateUsuario(Usuario producto);
    }
}
