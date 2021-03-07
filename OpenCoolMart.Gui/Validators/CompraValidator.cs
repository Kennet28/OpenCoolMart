using FluentValidation;
using OpenCoolMart.Gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCoolMart.Gui.Validators
{
    public class CompraValidator:AbstractValidator<CompraRequestDto>
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
