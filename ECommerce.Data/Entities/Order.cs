using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
