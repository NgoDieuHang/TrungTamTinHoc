using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TTTH.Validate
{
    public class AgreeValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (!Convert.ToBoolean(value.ToString()))
                {
                    return new ValidationResult("You much agree with terms conditions of us");
                }
            }
            else
            {
                return new ValidationResult("You much agree with terms conditions of us");
            }
            return ValidationResult.Success;
        }
    }
}