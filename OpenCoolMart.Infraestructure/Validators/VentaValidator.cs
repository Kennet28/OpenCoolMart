using FluentValidation;
using OpenCoolMart.Domain.DTOs;

namespace OpenCoolMart.Infraestructure.Validators
{
    public class VentaValidator:AbstractValidator<VentaRequestDto>
    {
        public VentaValidator()
        {
            RuleFor(venta => venta.VentaTotal)
                .GreaterThan(0)
                .GreaterThan(venta => venta.SubTotal);
            RuleFor(venta => venta.VentaTotal)
                .GreaterThan(0);
            RuleFor(venta => venta.FormaPago)
                .NotNull()
                .Length(3, 50);           
        }
    }
}
