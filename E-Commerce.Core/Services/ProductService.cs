using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Core.IServices;
using E_Commerce.DB.DTO;
using E_Commerce.DB;
using Microsoft.EntityFrameworkCore;
using E_Commerce.DB.Entities;

namespace E_Commerce.Core.Services
{
	public class ProductService : IProductService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		public ProductService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<ProductDto>> GetAllAsync()
		{
			var products = await _context.Products.ToListAsync();
			return _mapper.Map<List<ProductDto>>(products);
		}
		public async Task AddAsync(ProductCreateDto newProduct)
		{
			var entity = _mapper.Map<Product>(newProduct);
			_context.Products.Add(entity);
			await _context.SaveChangesAsync();
		}

	}

}
