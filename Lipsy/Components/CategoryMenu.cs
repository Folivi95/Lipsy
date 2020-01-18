using Lipsy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryMenu(ICategoryRepository category)
        {
            categoryRepository = category;
        }

        public IViewComponentResult Invoke()
        {
            var categories = this.categoryRepository.Categories.OrderBy(p => p.CategoryName);
            return View(categories);
        }
    }
}
