using ECommerce.Common.Models;
using ECommerce.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;

        /// <summary>
        /// The ProductController constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// To Create the Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateProduct(ProductItem product)
        {
            if (!ProductService.IsValidProduct(product))
            {
                return BadRequest("Invalid product data.");
            }

            ProductService.CreateProduct(product); 
            return Ok("Product created successfully.");
        }
    }
}
