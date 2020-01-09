using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Is18Validation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if(customer.BirthDate == null)
            {
                return new ValidationResult("Customer Birth Date is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Year;
            return (age >= 18) ?  ValidationResult.Success : new ValidationResult("Customer has to be age 18 od older for plan");
        }
    }
}