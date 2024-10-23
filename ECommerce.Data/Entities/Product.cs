using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
