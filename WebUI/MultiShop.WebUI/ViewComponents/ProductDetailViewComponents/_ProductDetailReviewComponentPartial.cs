﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var values = await _commentService.CommentListByProductId(id);
            return View(values);


        }
    }
}
