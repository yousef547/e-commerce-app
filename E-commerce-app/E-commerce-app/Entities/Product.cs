using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.Entities
{
    public class Product: BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name of the product

        [StringLength(500)]
        public string Description { get; set; } // Product description

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double Price { get; set; } // Product price

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int StockQuantity { get; set; } // Available stock
        public ICollection<OrderItem> OrderProducts { get; set; }


    }
}
