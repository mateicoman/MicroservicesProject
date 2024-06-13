using AutoMapper;
using ProductMicroservice.Domain.DTO;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Interfaces.Repositories;
using ProductMicroservice.Domain.Specifications;

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

    public async Task<IEnumerable<ProductDto>> FindAsync()
    {
        return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.FindAsync());
    }

    public async Task<ProductDto?> GetAsync(Guid id)
    {
        var result = await _productRepository.GetAsync(id)!;
        if (result is null)
        {
            return null;
        }
        return _mapper.Map<ProductDto>(result);
    }

    public async Task<ProductDto?> SaveAsync(ProductPostDto productPostDto)
    {
        if (await AlreadyExistsProductWithSameName(null, productPostDto.Name))
        {
            return null;
        }
        var product = _mapper.Map<Product>(productPostDto);
        await _productRepository.SaveAsync(product);
        return _mapper.Map<ProductDto>(await _productRepository.GetAsync(product.Id)!);
    }

    private async Task<bool> AlreadyExistsProductWithSameName(Guid? productId, string name)
    {
        var specification = new GetExistingProductByIdAndName(productId, name);
        var existing =  await _productRepository.GetAsync(specification)!;
        if(existing is null)
        {
            return false;
        }
        return true;
    }

    public async Task<ProductDto?> UpdateAsync(Guid productId, ProductPutDto productPutDto)
    {
        var product = await _productRepository.GetAsync(productId)!;

        if(product is null)
        {
            return null;
        }

        if (await AlreadyExistsProductWithSameName(productId, productPutDto.Name))
        {
            return null;
        }

        await _productRepository.UpdateAsync(_mapper.Map(productPutDto, product));
        return _mapper.Map<ProductDto>(await _productRepository.GetAsync(productId)!);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id)!;

        if(product is null)
        {
            return false;
        }

        await _productRepository.DeleteAsync(product);
        return true;
    }
}