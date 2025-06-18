using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultCompentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()

        {
            return View();
        }
    }
}
