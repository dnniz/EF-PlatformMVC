using DEMO.Web.Helpers;
using DEMO.Web.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEMO.Web.Models
{
    [FluentValidation.Attributes.Validator(typeof(UserValidator))]
    public class UserViewModel : ViewModel
    {
        //[Required(ErrorMessage = MessageValidation.CampoObl(""))]
        //[EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "El campo es obligatorio")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "El campo es ")]
        //[MinLength(8)]
        //[MaxLength(8)]
        public string DNI { get; set; }

        //[Required]
        public string FirstName { get; set; }

        //[Required]
        public string LastName { get; set; }

        public string MobilePhone { get; set; }
    }
}