using Lipsy.Data.Interfaces;
using Lipsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly ShoppingCart shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            this.appDbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            this.appDbContext.Orders.Add(order);

            var shoppingCartItems = this.shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    LipstickId = item.Lipstick.LipstickId,
                    OrderId = order.OrderId,
                    Price = item.Lipstick.Price
                };
                this.appDbContext.OrderDetails.Add(orderDetail);
            }

            this.appDbContext.SaveChanges();
        }
    }
}
