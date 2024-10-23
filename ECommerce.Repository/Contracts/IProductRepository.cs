using ECommerce.Common.Models;

namespace ECommerce.Repository.Contracts
{
    /// <summary>
    /// The Product Repository interface
    /// </summary>
    public interface IProductRepository
    { 
        public void CreateProduct(ProductItem product);
    }
}
