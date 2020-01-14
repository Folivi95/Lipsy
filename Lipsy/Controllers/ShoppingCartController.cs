using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lipsy.Interfaces;
using Lipsy.Models;
using Lipsy.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lipsy.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILipstickRepository lipstickRepository;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(ILipstickRepository lipstickRepository, ShoppingCart shoppingCart)
        {
            this.lipstickRepository = lipstickRepository;
            this.shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = this.shoppingCart.GetShoppingCartItems();
            this.shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = this.shoppingCart,
                ShoppingCartTotal = this.shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int lipstickId)
        {
            var selectedLipstick = this.lipstickRepository.Lipsticks.FirstOrDefault(p => p.LipstickId == lipstickId);
            if (selectedLipstick != null)
            {
                this.shoppingCart.AddToCart(selectedLipstick, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int lipstickId)
        {
            var selectedLipstick = this.lipstickRepository.Lipsticks.FirstOrDefault(p => p.LipstickId == lipstickId);
            if (selectedLipstick != null)
            {
                this.shoppingCart.RemoveFromCart(selectedLipstick);
            }

            return RedirectToAction("Index");
        }
    }
}
