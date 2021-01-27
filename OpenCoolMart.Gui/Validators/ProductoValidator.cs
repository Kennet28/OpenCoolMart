using FluentValidation;
using OpenCoolMart.Gui.Models;

namespace OpenCoolMart.Gui.Validators
{
    public class ProductoValidator:AbstractValidator<ProductoRequestDto>
    {
        public ProductoValidator()
        {
            RuleFor(producto => producto.CodigoProducto)
                .GreaterThan(0);
            RuleFor(producto => producto.Descripcion)
                .NotNull().WithMessage("Este campo no puede ser null")
                .NotEmpty().WithMessage("Este campo no puede ser vacio")
                .Length(3, 75);
            RuleFor(producto => producto.PrecioCompra)
                .GreaterThan(0);
            RuleFor(producto => producto.PrecioVenta)
                .GreaterThan(producto=>producto.PrecioCompra);
            RuleFor(producto => producto.Stock)
                .GreaterThan(0);
            RuleFor(producto => producto.Marca)
                .NotNull().WithMessage("Este campo no puede ser null")
                .NotEmpty().WithMessage("Este campo no puede ser vacio")
                .Length(3, 50);
            RuleFor(producto => producto.Clasificacion)
                .NotNull().WithMessage("Este campo no puede ser null")
                .NotEmpty().WithMessage("Este campo no puede ser vacio")
                .Length(3, 50);
            RuleFor(producto => producto.Descuento)
               .LessThanOrEqualTo(1)
               .GreaterThanOrEqualTo(0);
        }
    }
}
