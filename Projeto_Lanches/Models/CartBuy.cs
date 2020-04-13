using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projeto_Lanches.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.Models
{
    public class CartBuy
    {
        private readonly SnacksContext _context;

        public CartBuy(SnacksContext context)
        {
            _context = context;
        }
        public string Id { get; set; }
        public List<CartBuyItem> CartBuyItems { get; set; }

        public static CartBuy GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<SnacksContext>();
            string CartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", CartId);
            return new CartBuy(context)
            {
                Id = CartId
            };
        }
        
        public void AddCart(Snack snack, int amount)
        {
            var cartBuyItem = _context.CartBuyItens.SingleOrDefault(s => s.snack.Id == snack.Id && s.CartBuyId == Id);

            if (cartBuyItem == null)
            {
                cartBuyItem = new CartBuyItem()
                {
                    CartBuyId = Id,
                    snack = snack,
                    Amount = 1
                };
                _context.CartBuyItens.Add(cartBuyItem);
            }
            else
            {
                cartBuyItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveCart (Snack snack)
        {
            var cartBuyItem = _context.CartBuyItens.SingleOrDefault(s => s.snack.Id == snack.Id && s.CartBuyId == Id);

            var quantidadeLocal = 0;

            if(cartBuyItem != null)
            {
                if (cartBuyItem.Amount > 1)
                {
                    cartBuyItem.Amount--;
                    quantidadeLocal = cartBuyItem.Amount;
                }
                else
                {
                    _context.CartBuyItens.Remove(cartBuyItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CartBuyItem> GetCartBuyItems()
        {
            return CartBuyItems ?? (CartBuyItems =
                _context.CartBuyItens.Where(c => c.CartBuyId == Id).Include(s=>s.snack).ToList()); 
        }

        public void CartClean()
        {
            var CartItens = _context.CartBuyItens.Where(carrinho => carrinho.CartBuyId == Id);
            _context.CartBuyItens.RemoveRange(CartItens);
            _context.SaveChanges();
        }

        public decimal GetCartBuyTotal()
        {
            var total = _context.CartBuyItens.Where(c => c.CartBuyId == Id).Select(c => c.snack.Price * c.Amount).Sum();
            return total;
        }
    }
}

