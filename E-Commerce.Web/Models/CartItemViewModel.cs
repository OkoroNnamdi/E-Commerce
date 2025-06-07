namespace E_Commerce.Web.Models
{
	public class CartItemViewModel
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public decimal ProductPrice { get; set; }
		public int Quantity { get; set; }
	}
}
