using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ICajaService
    {
        Task AddCaja(Caja caja);
        Task DeleteCaja(int id);
        Task<IEnumerable<Caja>> GetCajas();
        Task<Caja> GetCaja(int id);
        Task UpdateCaja(Caja caja);
    }
}
