﻿using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Services
{
    public class VentaService : IVentaService
    {
        private IUnitOfWork _unitOfWork;
        public VentaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task CrearVerta(Venta venta)
        {
            Caja caja = new Caja();
            caja = await _unitOfWork.CajaRepository.GetById(venta.CajaId);
            caja.CantidadTotal = caja.CantidadTotal+venta.VentaTotal;
            await _unitOfWork.CajaRepository.Update(caja);
            await _unitOfWork.VentaRepository.CrearVerta(venta);
        }

        public async Task<IEnumerable<Venta>> GetVentas()
        {
            return await _unitOfWork.VentaRepository.GetAll();
        }

        public async Task<Venta> VerVenta(int id)
        {
            return await _unitOfWork.VentaRepository.VerVenta(id);
        }
    }
}
