using System.ComponentModel.DataAnnotations;

namespace DesafioMuralis2025.Application.Utils
{
    public class CepValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var cep = value as string;

            if (string.IsNullOrEmpty(cep) || !CepValidator.IsValidCep(cep))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

    }
}
