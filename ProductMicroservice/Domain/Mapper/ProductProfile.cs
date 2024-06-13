using AutoMapper;
using ProductMicroservice.Domain.Entities;
using ProductMicroservice.Domain.DTO;

namespace ProductMicroservice.Domain.Mapper;

public class ProductProfile: Profile
{
	public ProductProfile()
	{
		CreateMap<ProductPostDto, Product>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

		CreateMap<ProductPutDto, Product>();

        CreateMap<Product, ProductDto>();
    }
}

