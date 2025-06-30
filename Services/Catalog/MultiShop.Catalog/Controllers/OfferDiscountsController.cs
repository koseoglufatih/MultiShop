﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{

	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class OfferDiscountsController : ControllerBase
	{
		private readonly IOfferDiscountService _offerDiscountService;

		public OfferDiscountsController(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		[HttpGet]
		public async Task<IActionResult> OfferDiscountList()
		{
			var values = await _offerDiscountService.GetAllOfferDiscountAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdOfferDiscount(string id)
		{
			var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
		{
			await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
			return Ok("Özel Teklif başarıyla eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOfferDiscount(string id)
		{
			await _offerDiscountService.DeleteOfferDiscountAsync(id);
			return Ok("Özel Teklif başarıyla silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOfferDiscoun(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
			return Ok("Özel Teklif başarıyla güncellendi");
		}
	}
}
