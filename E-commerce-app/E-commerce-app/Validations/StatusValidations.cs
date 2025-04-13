using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.Validations
{
 

    public class StatusValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string status)
            {
                if (string.Equals(status, "Pending", StringComparison.OrdinalIgnoreCase) || string.Equals(status, "Delivered", StringComparison.OrdinalIgnoreCase) || string.Equals(status, "Shipped", StringComparison.OrdinalIgnoreCase) )
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("The status must be 'Pending' or 'Delivered' or 'Shipped'.");
            }
            return new ValidationResult("Invalid status.");
        }
    }
}
