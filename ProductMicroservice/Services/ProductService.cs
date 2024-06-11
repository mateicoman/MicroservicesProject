using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Bson;
using ProductMicroservice.Data;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Interfaces.Repositories;
using ProductMicroservice.Models;
using UserManagement.Domain.Specifications;

namespace ProductMicroservice.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Product>> FindAsync()
    {
        return await _productRepository.FindAsync();
    }

    public async Task<Product?> GetAsync(Guid id)
    {
        var result = await _productRepository.GetAsync(id);
        return result;
    }

    public async Task<Product?> SaveAsync(ProductPostDto productPostDto)
    {
        if (await GetExistingProductWithSameName(null, productPostDto.Name) is not null)
        {
            return null;
        }
        var product = _mapper.Map<Product>(productPostDto);
        await _productRepository.SaveAsync(product);
        return await _productRepository.GetAsync(product.Id);
    }

    private async Task<Product?> GetExistingProductWithSameName(Guid? productId, string name)
    {
        var specification = new GetExistingProductByIdAndName(productId, name);
        var existing =  await _productRepository.GetAsync(specification);
        if(existing is null)
        {
            return null;
        }
        return existing;
    }

    public async Task<Product?> UpdateAsync(Guid productId, ProductPutDto productPutDto)
    {
        var product = await _productRepository.GetAsync(productId);

        if(product is null)
        {
            return null;
        }

        if (await GetExistingProductWithSameName(productId, productPutDto.Name) is not null)
        {
            return null;
        }

        await _productRepository.UpdateAsync(_mapper.Map(productPutDto, product));
        return await _productRepository.GetAsync(productId);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);

        if(product is null)
        {
            return false;
        }

        await _productRepository.DeleteAsync(product);
        return true;
    }
}