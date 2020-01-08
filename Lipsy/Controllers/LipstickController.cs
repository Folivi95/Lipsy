﻿using Lipsy.Interfaces;
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

        public ViewResult Index()
        {
            LipstickViewModel vm = new LipstickViewModel();
            vm.Lipsticks = lipstickRepository.Lipsticks;
            vm.CurrentCategory = "Drink Category";
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
