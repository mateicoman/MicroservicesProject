

using ProductMicroservice.Domain.DTO;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> FindAsync();
    Task<Product> GetAsync(Guid id);
    Task<Product> SaveAsync(ProductPostDto productPostDto);
    Task<Product> UpdateAsync(Guid id, ProductPutDto productPutDto);
    Task<bool> DeleteAsync(Guid id);
}