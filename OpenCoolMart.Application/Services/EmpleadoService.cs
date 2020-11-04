using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Services
{
    public class EmpleadoService:IEmpleadoService
    {
        public IUnitOfWork _unitOfWork;
        public EmpleadoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddEmpleado(Empleado empleado)
        {
            Expression<Func<Empleado, bool>> expression = item => item.Id == empleado.Id;
            var empleados = await _unitOfWork.EmpleadoRepository.FindByCondition(expression);
            if (empleados.Any(item => item.Id == empleado.Id))
                throw new Exception("Este empleado ya ha sido registrado");


            await _unitOfWork.EmpleadoRepository.Add(empleado);
        }

        public async Task DeleteEmpleado(int id)
        {
            await _unitOfWork.EmpleadoRepository.Delete(id);
        }

        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            return await _unitOfWork.EmpleadoRepository.GetAll();
        }

        public async Task<Empleado> GetEmpleado(int id)
        {
            return await _unitOfWork.EmpleadoRepository.GetById(id);
        }

        public async Task UpdateEmpleado(Empleado empleado)
        {
            await _unitOfWork.EmpleadoRepository.Update(empleado);
        }
    }
}
