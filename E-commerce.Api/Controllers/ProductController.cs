using E_Commerce.Core.IServices;
using E_Commerce.DB.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService) => _productService = productService;

		[HttpGet(" GetProducts")]
		public async Task<IActionResult> GetProducts()
		{
			try
			{
				var products = await _productService.GetAllAsync();
				return Ok(products);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
		[HttpPost]
		public async Task<IActionResult> AddProduct([FromBody] ProductCreateDto productDto)
		{
			try
			{
				await _productService.AddAsync(productDto);
				return Ok(new { message = "Product added successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

	}
}
