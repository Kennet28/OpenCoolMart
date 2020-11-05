using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Infraestructure.Repositories
{
    public class VentaRepository : SQLRepository<Venta>, IVentaRepository
    {
        public VentaRepository(OpenCoolMartContext context):base(context)
        {

        }
        public async Task CrearVerta(Venta venta)
        {
            _context.Add(venta);
            foreach(var detalles in venta.DetallesVentas)
            {                
                _context.Add(detalles);            
                
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Venta> VerVenta(int id)
        {            
            return await _context.Set<Venta>().Include(x=>x.DetallesVentas).ThenInclude(y=>y.Producto).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
