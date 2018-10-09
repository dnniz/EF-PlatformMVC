using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.Web.Models.Validation
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.DNI).NotNull()//.WithMessage("El campo DNI es Obligatorio")
                               .Length(8, 8);//.WithMessage("El DNI debe ser válido");
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(X => X.LastName).NotNull();
        }
    }
}