using Confitec.Application.CustomValidation;
using Confitec.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Application.ViewModel
{
    public class CreateUserVm
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Birthdate]
        public DateTime Birthdate { get; set; }

        [EnumDataType(typeof(EducationLevel), ErrorMessage = "Escolaridade inválida")]
        public EducationLevel EducationLevel { get; set; }
    }
}
