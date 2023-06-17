using System.ComponentModel.DataAnnotations;

public class ValidDoBAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var dob = value as DateTime?;

        if (dob == null)
        {
            return ValidationResult.Success;
        }

        if (dob >= DateTime.Now)
        {
            return new ValidationResult("Date of birth cannot be in the future!");
        }

        return ValidationResult.Success;
    }
}
