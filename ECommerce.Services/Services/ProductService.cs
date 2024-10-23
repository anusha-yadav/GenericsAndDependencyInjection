using ECommerce.Common.Models;
using ECommerce.Repository.Contracts;
using ECommerce.Services.Contracts;

namespace ECommerce.Services.Services
{
    /// <summary>
    /// The Product Service
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        /// <summary>
        /// To validate the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool IsValidProduct(ProductItem product)
        {
            if (string.IsNullOrEmpty(product.ProductName) || product.ProductName.Length > 100)
            {
                return false; 
            }

            if (product.Price <= 0)
            {
                return false; 
            }

            return true; 
        }

        /// <summary>
        /// To create the product
        /// </summary>
        /// <param name="product"></param>
        public void CreateProduct(ProductItem product)
        {
            ProductRepository.CreateProduct(product);
        }
    }
}
