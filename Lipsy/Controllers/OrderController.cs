using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lipsy.Data.Interfaces;
using Lipsy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lipsy.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly ShoppingCart shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
    }
}