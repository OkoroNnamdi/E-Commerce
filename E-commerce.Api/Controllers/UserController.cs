using E_Commerce.Core.IServices;
using E_Commerce.Core.Services;
using E_Commerce.DB.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = E_Commerce.DB.DTO.RegisterRequest;

namespace E_commerce.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _UserService;
		public UserController(IUserService UserService)
		{
			_UserService = UserService;
		} 
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequest request)
		{
			try
			{
				var existing = await _UserService.FindByUsernameAsync(request.Username);
				if (existing != null)
					return Conflict("Username already exists");

				var user = await _UserService.RegisterAsync(request.Username, request.Password);
				return Ok(new { message = "Registration successful", userId = user.Id });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
		
			

		
		

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] RegisterRequest model)
		{
			var user = await _UserService.AuthenticateAsync(model.Username, model.Password);
			if (user == null)
				return Unauthorized("Invalid username or password");

			return Ok(new { message = "Login successful", userId = user.Id });
		}

	}

	//public record RegisterRequest(string Username, string Password);


}

