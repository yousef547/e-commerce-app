using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_commerce_app.Entities
{
    public class OrderStatus : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
