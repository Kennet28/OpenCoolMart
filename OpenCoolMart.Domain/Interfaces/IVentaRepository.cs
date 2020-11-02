using Microsoft.AspNetCore.Mvc;
using OpenCoolMart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface IVentaRepository:IRepository<Venta>
    {
        public Task CrearVerta(Venta venta);
        public Task<Venta> VerVenta(int id);
    }
}
