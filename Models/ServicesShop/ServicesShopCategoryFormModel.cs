﻿using Microsoft.AspNetCore.Mvc;

namespace HWASP.Models.ServicesShop
{
    public class ServicesShopCategoryFormModel
    {
        [FromForm(Name = "category-slug")]
        public string Slug { get; set; } = null!;
        [FromForm(Name = "category-name")]
        public string Name { get; set; } = null!;
        [FromForm(Name = "category-description")]
        public string Description { get; set; } = null!;
        [FromForm(Name = "category-image")]
        public IFormFile Image { get; set; } = null!;

    }
}
