using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class IsZeroInStockValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            return (movie.InStock > 0)
                ? ValidationResult.Success
                : new ValidationResult("Number in stock must be greater than 0");
        }
    }
}