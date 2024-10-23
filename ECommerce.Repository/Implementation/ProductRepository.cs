using ECommerce.Common.Models;
using ECommerce.Data.Entities;
using ECommerce.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDBContext ECommerceDBContext;

        public ProductRepository(ECommerceDBContext ecommerceDBContext)
        {
            ECommerceDBContext = ecommerceDBContext;
        }

        public void CreateProduct(ProductItem product)
        {
            if (product != null)
            {
                Product productItem = new()
                {
                    ProductName = product.ProductName,
                    Price = product.Price,
                    ProductDescription = product.ProductDescription,
                };
                ECommerceDBContext.Add(productItem);
                ECommerceDBContext.SaveChanges();
            }
        }
    }
}
