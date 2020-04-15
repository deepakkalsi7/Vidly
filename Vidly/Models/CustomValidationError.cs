using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class CustomValidationError:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if(movie.NumberInStock<=20 && movie.NumberInStock > 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The movies in the stock must be between 1 and 20");
            }
        }
    }
}