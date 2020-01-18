using Lipsy.Interfaces;
using Lipsy.Models;
using Lipsy.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Controllers
{
    public class LipstickController : Controller
    {
        private readonly ILogger<LipstickController> logger;
        private readonly ICategoryRepository categoryRepository;
        private readonly ILipstickRepository lipstickRepository;

        public LipstickController(ILogger<LipstickController> logger, ICategoryRepository category, ILipstickRepository lipstick)
        {
            this.logger = logger;
            categoryRepository = category;
            lipstickRepository = lipstick;
        }

        public ViewResult Index(string category)
        {
            string _category = category;
            IEnumerable<Lipstick> lipsticks = null;

            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                lipsticks = this.lipstickRepository.Lipsticks.OrderBy(n => n.LipstickId);
                currentCategory = "All Lipsticks";
            }
            else
            {
                if (string.Equals("Nude", _category, StringComparison.OrdinalIgnoreCase))
                {
                    lipsticks = this.lipstickRepository.Lipsticks.Where(n => n.Category.CategoryName.Equals("Nude")).OrderBy(p => p.Name);
                }
                else if (string.Equals("Party-Glam", _category, StringComparison.OrdinalIgnoreCase))
                {
                    lipsticks = this.lipstickRepository.Lipsticks.Where(n => n.Category.CategoryName.Equals("Party-Glam")).OrderBy(p => p.Name);
                }
                else if (string.Equals("Clear-Gloss", _category, StringComparison.OrdinalIgnoreCase))
                {
                    lipsticks = this.lipstickRepository.Lipsticks.Where(n => n.Category.CategoryName.Equals("Clear-Gloss")).OrderBy(p => p.Name);
                }
            }

            var lipstickViewModel = new LipstickViewModel
            {
                Lipsticks = lipsticks,
                CurrentCategory = currentCategory
            };

            return View(lipstickViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
