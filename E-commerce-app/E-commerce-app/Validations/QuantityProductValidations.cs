﻿using E_commerce_app.Data;
using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class QuantityForProductAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int quantity)
        {
            // Retrieve the ProductId from the validation context
            var productIdProperty = validationContext.ObjectType.GetProperty("ProductId");
            if (productIdProperty == null)
            {
                return new ValidationResult("Unknown product ID.");
            }

            var productId = (int)productIdProperty.GetValue(validationContext.ObjectInstance);

            var context = (DataContext)validationContext.GetService(typeof(DataContext));
            var product = context.Products.Find(productId);
            if(product == null)
            {
                return new ValidationResult("product already not exists.");
            }
            // Simulate a check against a data source (e.g., database)
            // You can replace this with your actual data source logic

            if (quantity > product.Stock)
            {
                return new ValidationResult($"Quantity for product {product.Name} is invalid.");
            }
        }
        return ValidationResult.Success;
    }
}