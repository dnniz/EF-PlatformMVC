using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.Web.Models
{
    public class ViewModel
    {
        public IList<ValidationFailure> Errors { get; set; }
        public bool Done { get; set; }
        public bool ModelValid { get; set; }
    }
}