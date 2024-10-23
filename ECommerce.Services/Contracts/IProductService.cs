using ECommerce.Common.Models;

namespace ECommerce.Services.Contracts
{
    /// <summary>
    /// The Product Service interface
    /// </summary>
    public interface IProductService
    {
        public void CreateProduct(ProductItem product);
        bool IsValidProduct(ProductItem product);
    }
}
