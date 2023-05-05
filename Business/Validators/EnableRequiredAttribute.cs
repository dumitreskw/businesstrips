using System.ComponentModel.DataAnnotations;

namespace BusinessTrips.Business.Validators;

public class EnableRequiredAttribute : ValidationAttribute
{
    public EnableRequiredAttribute(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var enabled = (bool)value!;

        if (enabled == false)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}