﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
      
        private readonly IProductImageService _productImageService;
        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
           
            _productImageService = productImageService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = _productImageService.GetByProductIdImageAsync(id);
            return View(values);

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:7236/api/ProductImages/ProductImagesByProductId?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
    }
}
