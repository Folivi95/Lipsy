using Lipsy.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext appDbContext;

        public ShoppingCart(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = serviceProvider.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Lipstick lipstick, int amount)
        {
            var shoppingCartItem = appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Lipstick.LipstickId == lipstick.LipstickId &&
                                                                                       s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Lipstick = lipstick,
                    Amount = 1
                };

                appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Lipstick lipstick)
        {
            var shoppingCartItem = appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Lipstick.LipstickId == lipstick.LipstickId &&
                                                                                       s.ShoppingCartId == ShoppingCartId);

            int localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            appDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
                                                                                             .Include(s => s.Lipstick).ToList());
        }

        public void ClearCart()
        {
            var cartItems = appDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(c => c.Lipstick.Price * c.Amount).Sum();

            return total;
        }
    }
}
