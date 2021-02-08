using FluentValidation;
using OpenCoolMart.Domain.DTOs;

namespace OpenCoolMart.Infraestructure.Validators
{
    public class ClienteValidator:AbstractValidator<ClienteRequestDto>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nombre)
                .NotNull().WithMessage("Nombre no puede ser null")
                .NotEmpty().WithMessage("Nombre no puede ser vacio")
                .Length(3, 50);
            RuleFor(cliente=>cliente.Domicilio)
                .NotNull().WithMessage("Domicilio no puede ser null")
                .NotEmpty().WithMessage("Domicilio no puede ser vacio")
                .Length(3, 50);
            RuleFor(cliente => cliente.Telefono)
                .LessThanOrEqualTo(9999999999);
            RuleFor(cliente=>cliente.Correo)
                .NotNull().WithMessage("Correo no puede ser null")
                .NotEmpty().WithMessage("Correo no puede ser vacio")
                .Length(3, 50);
        }
    }
}
