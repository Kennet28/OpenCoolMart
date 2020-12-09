
using System;
using System.Data;
using FluentValidation;
using OpenCoolMart.Gui.Models;

namespace OpenCoolMart.Gui.Validators
{
    public class FacturaValidator: AbstractValidator<FacturaRequestDto>
    {
        public FacturaValidator()
        {
            RuleFor(fac => fac.ClienteId)
                .NotNull().WithMessage("Debe seleccionar un cliente")
                .NotEmpty().WithMessage("Debe seleccionar un cliente");
            RuleFor(fac => fac.VentaId)
                .NotNull().WithMessage("Debe seleccionar una venta")
                .NotEmpty().WithMessage("Debe seleccionar un venta");
            RuleFor(fac => fac.UsoCFDI)
                .NotNull().WithMessage("Seleccione el uso de CFDI")
                .NotEmpty().WithMessage("Seleccione el uso de CFDI");
            // RuleFor(fac => fac.)
        }
    }
}