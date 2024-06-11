using System;
using AutoMapper;
using ProductMicroservice.Models;

namespace ProductMicroservice.Mapper
{
	public class ProductProfile: Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductPostDto, Product>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

			CreateMap<ProductPutDto, Product>();	
		}
	}
}

