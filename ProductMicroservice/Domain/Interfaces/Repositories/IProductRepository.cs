using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.Interfaces.Repositories;

namespace ProductMicroservice.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}

