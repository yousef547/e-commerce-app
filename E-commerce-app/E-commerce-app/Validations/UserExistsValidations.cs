
using E_commerce_app.Data;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.DTOs
{
    internal class UserExistsValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (DataContext)validationContext.GetService(typeof(DataContext));
            var id = value as string;

            // Check if the email exists in the database
            if (!context.Customers.Any(u => u.Id == (int)value))
            {
                return new ValidationResult("user already not exists.");
            }

            return ValidationResult.Success;
        }
    }
}