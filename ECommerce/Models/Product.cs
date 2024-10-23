namespace ProductManagement.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public string ProductCategory { get; set; }
    }
}
