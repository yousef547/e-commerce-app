using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_app.Entities
{
    public class Order : BaseEntity
    {

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } // Assuming you have a Customer entity

        public DateTime OrderDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } 

        public ICollection<OrderItem> OrderProducts { get; set; }
        public ICollection<OrderStatus> OrderStatus { get; set; }

    }
}
