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
    public class ClienteService:IClienteService
    {
        public IUnitOfWork _unitOfWork;
        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCliente(Cliente cliente)
        {
            Expression<Func<Cliente, bool>> expression = item => item.Id == cliente.Id;
            var clientes = await _unitOfWork.ClienteRepository.FindByCondition(expression);
            if (clientes.Any(item => item.Id == cliente.Id))
                throw new Exception("Este cliente ya ha sido registrado");


            await _unitOfWork.ClienteRepository.Add(cliente);
        }

        public async Task DeleteCliente(int id)
        {
            await _unitOfWork.ClienteRepository.Delete(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _unitOfWork.ClienteRepository.GetAll();
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await _unitOfWork.ClienteRepository.GetById(id);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            await _unitOfWork.ClienteRepository.Update(cliente);
        }
    }
}
