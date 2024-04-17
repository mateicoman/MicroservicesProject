using ProductMicroservice.Models;

namespace ProductMicroservice.Interfaces;

public interface IProductService
{
    public IEnumerable<Product> FindProducts();
    public Product GetProduct(string id);
    public Product AddProduct(Product product);
    public Product UpdateProduct(Product product);
    public bool DeleteProduct(string id);
}