using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IEmpleadoService
    {
        Task AddEmpleado(Empleado empleado);
        Task DeleteEmpleado(int id);
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<Empleado> GetEmpleado(int id);
        Task UpdateEmpleado(Empleado empleado);
    }
}
