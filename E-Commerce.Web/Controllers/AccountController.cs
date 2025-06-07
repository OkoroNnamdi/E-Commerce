using E_Commerce.Web.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;

namespace E_Commerce.Web.Controllers
{
	public class AccountController : Controller
	{
		Uri basaAddress = new Uri("https://localhost:7045/api");
		private readonly HttpClient _client;
		public AccountController(HttpClient client)
		{
			 _client = client;
			_client.BaseAddress = basaAddress;
		}
		[HttpGet]
		public IActionResult Login() => View();

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			try
			{
				string data = JsonConvert.SerializeObject(model);
				StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await _client.PostAsync(basaAddress + "/User/Login", content);

				if (response.IsSuccessStatusCode)
				{
					TempData["successMessage"] = "Login successful";
					return RedirectToAction("Index", "Product");
				}
				else
				{
					string errorResponse = await response.Content.ReadAsStringAsync();

					// Try to parse validation errors
					var errorObj = JsonConvert.DeserializeObject<ValidationErrorResponse>(errorResponse);
					if (errorObj?.Errors != null)
					{
						foreach (var error in errorObj.Errors)
						{
							foreach (var message in error.Value)
							{
								ModelState.AddModelError(error.Key, message);
							}
						}
					}
					else
					{
						TempData["errorMessage"] = "Login failed.";
					}

					return View("Login", model);
				}

			}
			catch (Exception ex)
			{
				TempData["errorMessage"] = $"Exception: {ex.Message}";
				return View("Login", model);
			}
		}

		public IActionResult Index()
		{
			return RedirectToAction("Login");
		}

	}
}
