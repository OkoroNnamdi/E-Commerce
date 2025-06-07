using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Core.IServices;
using E_Commerce.DB.DTO;
using E_Commerce.DB.Entities;
using E_Commerce.DB;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Core.Services
{
	public class CartService : ICartService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		public CartService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<CartItemDto>> GetCartItemsAsync()
		{
			var items = await _context.CartItems.Include(ci => ci.Product).ToListAsync();
			return _mapper.Map<List<CartItemDto>>(items);
		}

		public async Task AddToCartAsync(int productId, int quantity)
		{
			var existing = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == productId);
			if (existing != null)
			{
				existing.Quantity += quantity;
			}
			else
			{
				await _context.CartItems.AddAsync(new CartItem
				{
					ProductId = productId,
					Quantity = quantity
					
				});
			}
			await _context.SaveChangesAsync();
		}

		public async Task RemoveFromCartAsync(int productId)
		{
			var item = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == productId);
			if (item != null)
			{
				_context.CartItems.Remove(item);
				await _context.SaveChangesAsync();
			}
		}
	}
}
