
using E_commerce_app.Data;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce_app.DTOs
{
    internal class ProductExistsValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (DataContext)validationContext.GetService(typeof(DataContext));

            // Check if the email exists in the database
            if (!context.Products.Any(u => u.Id == (int)value))
            {
                return new ValidationResult("product already not exists.");
            }

            return ValidationResult.Success;
        }
    }
}