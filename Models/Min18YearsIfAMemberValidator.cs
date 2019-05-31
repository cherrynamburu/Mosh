using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mosh.Models
{
    public class Min18YearsIfAMemberValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.payAsYouGo)           
                    return ValidationResult.Success;                     
                                      

            if (customer.BirthDate == null)
                return new ValidationResult("Birth Date is Required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer Should atleast be 18 Years old to go on a membership!");

        }
    }
}