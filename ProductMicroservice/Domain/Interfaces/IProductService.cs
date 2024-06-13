

using ProductMicroservice.Domain.DTO;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> FindAsync();
    Task<ProductDto?> GetAsync(Guid id);
    Task<ProductDto?> SaveAsync(ProductPostDto productPostDto);
    Task<ProductDto?> UpdateAsync(Guid id, ProductPutDto productPutDto);
    Task<bool> DeleteAsync(Guid id);
}