using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class IfFutureDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if(movie.DateAdded >= DateTime.Now)
                return new ValidationResult("Date Added cannot be in the future.");
            if (movie.ReleasedDate >= DateTime.Now)
                return new ValidationResult("Release Date cannot be in the future.");
            return ValidationResult.Success;
        }
    }
}