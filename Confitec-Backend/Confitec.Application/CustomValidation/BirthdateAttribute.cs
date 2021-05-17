using Confitec.Application.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Application.CustomValidation
{
    public class BirthdateAttribute : ValidationAttribute
    {
        public DateTime Birthdate { get; private set; }

        public BirthdateAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (CreateUserVm)validationContext.ObjectInstance;

            if (user.Birthdate > DateTime.Now)
            {
                return new ValidationResult("A data de nascimento não pode ser maior que hoje");
            }

            return ValidationResult.Success;
        }

    }
}
