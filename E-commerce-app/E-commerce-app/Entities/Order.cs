using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_app.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } // Assuming you have a Customer entity

        public DateTime OrderDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // "Pending" or "Delivered"

        public double TotalPrice { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
