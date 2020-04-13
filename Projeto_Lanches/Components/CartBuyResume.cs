using Microsoft.AspNetCore.Mvc;
using Projeto_Lanches.Models;
using Projeto_Lanches.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.Components
{
    public class CartBuyResume : ViewComponent
    {
        private readonly CartBuy _cartBuy;

        public CartBuyResume(CartBuy cartBuy)
        {
            _cartBuy = cartBuy;
        }

        public IViewComponentResult Invoke()
        {
            var items = _cartBuy.GetCartBuyItems();
            _cartBuy.CartBuyItems = items;

            var cartBuyVM = new CartBuyViewModel
            {
                cartBuy = _cartBuy,
                cartBuyTotal = _cartBuy.GetCartBuyTotal()
            };
            return View(cartBuyVM);
        }
    }
}
