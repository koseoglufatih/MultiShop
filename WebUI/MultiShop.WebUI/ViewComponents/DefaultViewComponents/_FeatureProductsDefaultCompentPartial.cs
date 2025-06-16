using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

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
