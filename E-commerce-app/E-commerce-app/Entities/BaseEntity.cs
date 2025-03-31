using System.ComponentModel.DataAnnotations;

namespace E_commerce_app.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
