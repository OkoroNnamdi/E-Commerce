using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.DB.DTO;
using E_Commerce.DB.Entities;

namespace E_Commerce.DB.AutoMapper
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductDto>();
			CreateMap<ProductCreateDto, Product>();
			CreateMap<User , RegisterRequest>();
			CreateMap<RegisterRequest, User>();
			CreateMap<CartItem, CartItemDto>()
				.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
				.ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product != null ? src.Product.Price : 0));
		}
	}
}
