using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class AgeRule:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           
            var Customer = (Customer)validationContext.ObjectInstance;
            if (Customer.MembershipTypeId == MembershipType.unknown|| Customer.MembershipTypeId==MembershipType.notMember )
                return ValidationResult.Success;
            var age = DateTime.Today.Year - Customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Age must be above 18 for the membership");

                  
        }
       
    }
}