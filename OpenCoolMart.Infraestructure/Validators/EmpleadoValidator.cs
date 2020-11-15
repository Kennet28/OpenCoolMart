using FluentValidation;
using OpenCoolMart.Domain.DTOs;
using System;

namespace OpenCoolMart.Infraestructure.Validators
{
    public class EmpleadoValidator:AbstractValidator<EmpleadoRequestDto> 
    {
        public EmpleadoValidator()
        {
            RuleFor(Empleado => Empleado.Telefono)
                .GreaterThan(0).WithMessage("Este campo no puede estar vacio")
                .LessThan(10).WithMessage("Debe contener 10 caracteres")
                .GreaterThan(10).WithMessage("Debe contener 10 caracteres");
            RuleFor(Empleado => Empleado.CodigoEmpleado)
                .GreaterThan(0).WithMessage("Este campo no puede estar vacio")
                .LessThan(8).WithMessage("Debe contener minimo 8 caracteres");
            RuleFor(Empleado => Empleado.Nombre)
                .NotNull().WithMessage("Este campo no puede estar vacio")
                .NotEmpty().WithMessage("Este campo no puede estar vacio")
                .Length(3, 50);
        }
    }
}
