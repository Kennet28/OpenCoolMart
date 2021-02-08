using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IClienteService
    {
        Task AddCliente(Cliente cliente);
        Task DeleteCliente(int id);
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(int id);
        Task UpdateCliente(Cliente cliente);
    }
}
