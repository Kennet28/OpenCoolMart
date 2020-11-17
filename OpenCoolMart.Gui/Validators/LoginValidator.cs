using FluentValidation;
using OpenCoolMart.Gui.Models;

namespace OpenCoolMart.Gui.Validators
{
    public class LoginValidator:AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(login => login.Email)
                .NotNull().WithMessage("Este campo no puede ser null")
                .NotEmpty().WithMessage("Este campo no puede ser vacio");
            RuleFor(login => login.Password)
                .NotNull().WithMessage("Este campo no puede ser null")
                .NotEmpty().WithMessage("Este campo no puede ser vacio")
                .Length(8, 15);
            RuleFor(login => login.status).NotEqual(true).WithMessage("Correo y contraseña no validos");
        }
    }
}
