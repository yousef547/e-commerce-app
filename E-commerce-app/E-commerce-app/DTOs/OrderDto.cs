using E_commerce_app.Validations;
using Hotel_booking.Helpers;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.DTOs
{
    public class OrderDto
    {
        [UserExistsValidations]
        [Required]
        public int CutomerId { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; } 
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        [ProductExistsValidations]
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        [QuantityForProduct]
        public int Quantity { get; set; }
    }

    public class RetrieveOrderDetailDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

    }

    public class UpdateOrderDto
    {
        [Required]
        public int OrderId { get; set; }
        [StatusValidations]
        public string Status { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }

    }

    public class RetrieveOrderDto
    {
        public int Id { get; set; }
        public string CutomerName { get; set; }
        public string Status { get; set; }
        public List<RetrieveOrderDetailDto> products { get; set; }


    }

}
