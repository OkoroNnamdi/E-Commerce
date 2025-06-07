using E_Commerce.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;
		public CartController(ICartService cartService) => _cartService = cartService;

		[HttpGet]
		public async Task<IActionResult> GetCart()
		{
			try
			{
				var cart = await _cartService.GetCartItemsAsync();
				return Ok(cart);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
		[HttpPost("add")]
		public async Task<IActionResult> AddToCart(int productId, int quantity)
		{
			try
			{
				await _cartService.AddToCartAsync(productId, quantity);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
		[HttpPost("remove")]
		public async Task<IActionResult> RemoveFromCart(int productId)
		{
			try
			{
				await _cartService.RemoveFromCartAsync(productId);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
		[HttpPost("update")]
		public async Task<IActionResult> UpdateQuantity(int productId, int quantity)
		{
			try
			{
				await _cartService.AddToCartAsync(productId, quantity); // reuse logic
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

	}
}
