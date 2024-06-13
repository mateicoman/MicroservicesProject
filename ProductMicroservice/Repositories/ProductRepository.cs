using AutoMapper;
using ProductMicroservice.Interfaces.Repositories;
using ProductMicroservice.Domain.Entities;

namespace ProductMicroservice.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ProductContext context, IMapper mapper) : base(context, mapper)
    {
    }
}

