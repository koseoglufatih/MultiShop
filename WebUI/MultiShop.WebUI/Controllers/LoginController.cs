using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public LoginController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
		{
			var client = _httpClientFactory.CreateClient();
			var content = new StringContent(JsonSerializer.Serialize(createLoginDto),Encoding.UTF8,"application/json");
			var response = await client.PostAsync("https://localhost:7169/api/logins",content);
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData,new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				if (tokenModel != null)
				{


				}
			}
			return View();
		}
	}
}
