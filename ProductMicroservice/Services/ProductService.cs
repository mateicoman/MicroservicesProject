using MongoDB.Bson;
using ProductMicroservice.Data;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;

namespace ProductMicroservice.Services;

public class ProductService: IProductService
{
    private readonly ProductContext _productContext;

    public ProductService(ProductContext productContext)
    {
        _productContext = productContext;
    }

    public IEnumerable<Product> FindProducts()
    {
        return _productContext.Products.ToList();
    }

    public Product GetProduct(string id)
    {
        return _productContext.Products.Find(id);
    }

    public Product AddProduct(Product product)
    {
        product.Id = Guid.NewGuid().ToString();
        var result = _productContext.Products.Add(product);
        _productContext.SaveChanges();
        return result.Entity;
    }
    
    public Product UpdateProduct(Product product)
    {
        var result = _productContext.Products.Update(product);
        _productContext.SaveChanges();
        return result.Entity;
    }
    public bool DeleteProduct(string id)
    {
        var filteredData = _productContext.Products.Find(id);
        var result = _productContext.Remove(filteredData);
        _productContext.SaveChanges();
        return result is not null;
    }
}