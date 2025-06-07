using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DB.DTO
{
	public class CartItemDto
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public decimal ProductPrice { get; set; }
		public int Quantity { get; set; }
	}
}
