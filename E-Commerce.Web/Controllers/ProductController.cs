using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.Web.Controllers
{
	public class ProductController : Controller
	{
		Uri basaAddress = new Uri("https://localhost:7045/api");
		private readonly HttpClient _client;
		public ProductController(HttpClient client)
		{
			_client = client;
			_client.BaseAddress = basaAddress;
		}
		[HttpGet]
		public IActionResult Index()
		{
			try
			{
				List<ProductViewModel> accounts = new List<ProductViewModel>();
				HttpResponseMessage response = _client.GetAsync(_client.BaseAddress
					+ "/Product/ GetProducts").Result;
				if (response.IsSuccessStatusCode)
				{
					string data = response.Content.ReadAsStringAsync().Result;
					accounts = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
				}
				return View(accounts);
			}
			catch (Exception)
			{

				return View();
			}

		}
	}
}
