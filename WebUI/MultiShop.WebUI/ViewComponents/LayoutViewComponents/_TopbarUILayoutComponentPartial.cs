﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.LayoutViewComponents
{
    public class _TopbarUILayoutComponentPartial :ViewComponent
     {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
