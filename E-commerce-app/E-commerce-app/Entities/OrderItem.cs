using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.Entities
{
    public class OrderItem : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Subtotal { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
