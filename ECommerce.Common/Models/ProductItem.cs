namespace ECommerce.Common.Models
{
    /// <summary>
    /// The Product Item
    /// </summary>
    public class ProductItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
