using FluentValidation;
using OpenCoolMart.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Infraestructure.Validators
{
    class CompraValidator: AbstractValidator<CompraRequestDto>
    {
        public CompraValidator()
        {
            RuleFor(compra => compra.CompraProductos)
                .NotNull();
            RuleFor(compra => compra.PrecioTotal)
                .GreaterThan(0);
            RuleFor(compra => compra.ProveedorId)
                .NotNull();
            RuleFor(compra => compra.EmpleadoId)
                .NotNull();
        }
    }
}
