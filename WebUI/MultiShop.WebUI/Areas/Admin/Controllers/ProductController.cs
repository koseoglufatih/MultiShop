﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;


        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

       

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBagList();
            var values = await _productService.GetAllProductAsync();
            return View(values);
           
        }


        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7236/api/Products/ProductListWithCategory");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            return View();
        }


        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            ProductViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7236/api/Categories");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();


            //var values = await _productService.GetAllProductAsync();
            //return View(values);


            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            //List<SelectListItem> categoryValues = (from x in values
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = x.CategoryName,
            //                                           Value = x.CategoryId
            //                                       }).ToList();
            //ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createProductDto);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7236/api/Products", content);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Product", new { area = "Admin" });
            //}
            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"https://localhost:7236/api/Products?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Product", new { area = "Admin" });
            //}
            return View();
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            //ViewBag.v1 = "Ana Sayfa";
            //ViewBag.v2 = "Ürünler";
            //ViewBag.v3 = "Ürün Güncelleme Sayfası";
            //ViewBag.v0 = "Ürün İşlemleri";

            //var client1 = _httpClientFactory.CreateClient();
            //var responseMessage1 = await client1.GetAsync("https://localhost:7236/api/Categories");
            //var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            //var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
            //List<SelectListItem> categoryValues1 = (from x in values1
            //                                        select new SelectListItem
            //                                        {
            //                                            Text = x.CategoryName,
            //                                            Value = x.CategoryId
            //                                        }).ToList();
            //ViewBag.CategoryValues = categoryValues1;

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:7236/api/Products/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            //    return View(values);
            //}
            return View();
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var JsonData = JsonConvert.SerializeObject(updateProductDto);
            //StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync($"https://localhost:7236/api/Products/", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Product", new { area = "Admin" });
            //}
            return View();
        }

        void ProductViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";
        }

    }

}

