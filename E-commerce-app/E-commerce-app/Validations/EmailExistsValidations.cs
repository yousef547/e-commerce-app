using E_commerce_app.Data;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.Validations
{

    public class EmailExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (DataContext)validationContext.GetService(typeof(DataContext));
            var email = value as string;

            // Check if the email exists in the database
            if (context.Customers.Any(u => u.Email == email))
            {
                return new ValidationResult("Email already exists.");
            }

            return ValidationResult.Success;
        }
    }

}
