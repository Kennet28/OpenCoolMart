using FluentValidation;
using OpenCoolMart.Gui.Models;
using System;

namespace OpenCoolMart.Gui.Validators
{
    public class EmpleadoValidator:AbstractValidator<EmpleadoUsuarioModel> 
    {
        public EmpleadoValidator()
        {
            RuleFor(empleado => empleado.Empleado.Telefono)
                .GreaterThan(0).WithMessage("Este campo no puede estar vacio");
            RuleFor(empleado => empleado.Empleado.CodigoEmpleado)
                .GreaterThan(0).WithMessage("Este campo no puede estar vacio");
            RuleFor(empleado => empleado.Empleado.Nombre)
                .NotNull().WithMessage("Este campo no puede estar vacio")
                .NotEmpty().WithMessage("Este campo no puede estar vacio")
                .Length(3, 50);
            RuleFor(usuario => usuario.Usuario.Contrasenia)
               .NotNull().WithMessage("Este campo no puede estar vacio")
               .NotEmpty().WithMessage("Este campo no puede estar vacio")
               .Length(8, 15);
            RuleFor(Usuario => Usuario.Usuario.Correo)
                .NotNull().WithMessage("Este campo no puede ser vacio")
                .NotEmpty().WithMessage("Este campo no puede estar vacio");
            RuleFor(Usuario => Usuario.Usuario.PerfilId)
                .NotNull().WithMessage("Este campo no puede estar vacio ")
                .NotEmpty().WithMessage("Este campo no puede estar vacio");
        }
    }
}
