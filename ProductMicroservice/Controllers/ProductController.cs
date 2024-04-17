using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;

namespace ProductMicroservice.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IEnumerable<Product> ProductList()
        {
            var productList = _productService.FindProducts();
            return productList;

        }
        [HttpGet("{id}")]
        public Product GetProductById(string id)
        {
            return _productService.GetProduct(id);
        }
        [HttpPost]
        public Product AddProduct(Product product)
        {
            return _productService.AddProduct(product);
        }
        [HttpPut]
        public Product UpdateProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }
        [HttpDelete("{id}")]
        public bool DeleteProduct(string id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}