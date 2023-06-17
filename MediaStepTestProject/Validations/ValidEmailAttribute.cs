using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class ValidEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var email = value as string;

        if (email == null)
        {
            return new ValidationResult("Email cannot be null!");
        }

        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        if (!regex.IsMatch(email))
        {
            return new ValidationResult("Invalid email format!");
        }

        return ValidationResult.Success;
    }
}

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
