﻿namespace E_Commerce.Web.Models
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string ImageUrl { get; set; } = string.Empty;
	}
}
