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
    public class CompraRepository : SQLRepository<Compra>, ICompraRepository
    {
        public CompraRepository(OpenCoolMartContext context):base(context)
        {

        }
    }
}
