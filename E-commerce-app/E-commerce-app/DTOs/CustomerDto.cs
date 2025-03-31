using E_commerce_app.Data;
using E_commerce_app.DTOs;
using E_commerce_app.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.DTOs
{
    public class CustomerDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Full name

        [Required]
        [EmailExists]
        [StringLength(100)]
        public string Email { get; set; } // Email address

        [Phone]
        [StringLength(15)]
        public string Phone { get; set; } // Phone number
    }
}
