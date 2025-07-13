using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }
        [Route("Index")]
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var values = await _productService.GetProductsWithCategoryByCategoryIdAynsc(id);
            return View(values);


        }
    }
}

