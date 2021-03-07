using FluentValidation;
using OpenCoolMart.Gui.Models;

namespace OpenCoolMart.Gui.Validators
{
    public class ProveedorValidator:AbstractValidator<ProveedorRequestDto>
    {
        public ProveedorValidator()
        {
            RuleFor(proveedor => proveedor.Nombre)
               .NotNull()
               .NotEmpty()
               .Length(3, 250);
            RuleFor(proveedor => proveedor.Correo)
                .NotNull()
               .NotEmpty()
               .Length(12, 100);
            RuleFor(proveedor => proveedor.Direccion)
                .NotNull()
               .NotEmpty()
               .Length(10, 100);
        }
    }
}
