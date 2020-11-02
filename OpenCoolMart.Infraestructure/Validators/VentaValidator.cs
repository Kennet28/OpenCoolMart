using FluentValidation;
using OpenCoolMart.Domain.DTOs;
using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Infraestructure.Validators
{
    public class VentaValidator:AbstractValidator<VentaRequestDto>
    {
        public VentaValidator()
        {
            RuleFor(venta => venta.FormaPago)
                .NotNull()
                .Length(3, 50);           
        }
    }
}
