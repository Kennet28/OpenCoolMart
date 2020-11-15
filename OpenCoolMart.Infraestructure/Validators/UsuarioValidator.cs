using FluentValidation;
using OpenCoolMart.Domain.DTOs;

namespace OpenCoolMart.Infraestructure.Validators
{
    public class UsuarioValidator:AbstractValidator<UsuarioRequestDto> 
    {
        public UsuarioValidator()
        {
            RuleFor(Usuario => Usuario.Contrasenia)
                .NotNull().WithMessage("Este campo no puede estar vacio")
                .NotEmpty().WithMessage("Este campo no puede estar vacio")
                .Length(8, 15);
            RuleFor(Usuario => Usuario.Correo)
                .NotNull().WithMessage("Este campo no puede ser vacio")
                .NotEmpty().WithMessage("Este campo no puede estar vacio");
            RuleFor(Usuario => Usuario.PerfilId)
                .NotNull().WithMessage("Este campo no puede estar vacio ")
                .NotEmpty().WithMessage("Este campo no puede estar vacio");
        }
    }
}
