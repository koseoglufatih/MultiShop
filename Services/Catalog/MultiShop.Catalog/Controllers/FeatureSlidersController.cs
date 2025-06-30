using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureSlidersController : ControllerBase
	{
		private readonly IFeatureSliderServices _featureSliderServices;

		public FeatureSlidersController(IFeatureSliderServices featureSliderServices)
		{
			_featureSliderServices = featureSliderServices;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureSliderList()
		{
			var values = await _featureSliderServices.GetAllFeatureSliderAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureSliderById(string id)
		{
			var values = await _featureSliderServices.GetByIdtFeatureSliderAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDtos createFeatureSliderDtos)
		{
			await _featureSliderServices.CreateFeatureSliderAsync(createFeatureSliderDtos);
			return Ok("Öne çıkan görsel başarıyla eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteFeatureSlider(string id)
		{
			await _featureSliderServices.DeleteFeatureSliderAsync(id);
			return Ok("Öne çıkan görsel başarıyla silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDtos)
		{
			await _featureSliderServices.UpdateFeatureSliderAsync(updateFeatureSliderDtos);
			return Ok("Öne çıkan görsel başarıyla güncellendi");
		}
	}
}

