using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DB.DTO;

namespace E_Commerce.Core.IServices
{
	public  interface ICartService
	{
		Task<List<CartItemDto>> GetCartItemsAsync();
		Task AddToCartAsync(int productId, int quantity);
		Task RemoveFromCartAsync(int productId);
	}
}
