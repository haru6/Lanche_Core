using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Lanches.Models;
using Projeto_Lanches.Repositories;

namespace Projeto_Lanches.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _repo;
        private readonly CartBuy _cartBuy;

        public RequestController(IRequestRepository repo, CartBuy cartBuy)
        {
            _repo = repo;
            _cartBuy = cartBuy;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Request request)
        {
            var items = _cartBuy.GetCartBuyItems();
            _cartBuy.CartBuyItems = items;

            if(_cartBuy.CartBuyItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, inclua um lanche...");
            }

            if (ModelState.IsValid)
            {
                _repo.CreateRequest(request);
                ViewBag.CheckoutCompleteMessage = "Obrigado pelo seu pedido";
                ViewBag.TotalRequest = _cartBuy.GetCartBuyTotal();
                _cartBuy.CartClean();
                return View("~/Views/Request/CheckoutComplete.cshtml", request);
            }

            return View(request);
        }
    }
}