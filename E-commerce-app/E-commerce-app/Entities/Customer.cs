using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Full name

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } // Email address

        [Phone]
        [StringLength(15)]
        public string Phone { get; set; } // Phone number

        public string Address { get; set; } // Address number
    }
}
