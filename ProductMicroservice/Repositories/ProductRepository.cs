using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Data;
using ProductMicroservice.Interfaces.Repositories;
using ProductMicroservice.Models;

namespace ProductMicroservice.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

