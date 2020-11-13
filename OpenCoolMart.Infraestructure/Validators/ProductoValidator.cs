using FluentValidation;
using OpenCoolMart.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCoolMart.Infraestructure.Validators
{
    public class ProductoValidator:AbstractValidator<ProductoRequestDto> 
    {
        public ProductoValidator()
        {
            RuleFor(producto => producto.Descripcion)
                .NotNull().WithMessage("Este campo no puede ser null")
                .NotEmpty().WithMessage("Este campo no puede ser vacio")
                .Length(3, 75);
            RuleFor(producto => producto.Marca)
                .NotNull().WithMessage("Este campo no puede ser null")
                .NotEmpty().WithMessage("Este campo no puede ser vacio")
                .Length(3, 50);
            RuleFor(producto => producto.Clasificacion)
                .NotNull().WithMessage("Este campo no puede ser null")
                .NotEmpty().WithMessage("Este campo no puede ser vacio")
                .Length(3, 50);                
        }
    }
}
