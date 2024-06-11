using System;
using ProductMicroservice.Models;
using UserManagement.Domain.Interfaces.Repositories;

namespace ProductMicroservice.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}

