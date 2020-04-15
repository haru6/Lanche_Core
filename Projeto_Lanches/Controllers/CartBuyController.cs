using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Lanches.Models;
using Projeto_Lanches.Repositories;
using Projeto_Lanches.ViewModel;

namespace Projeto_Lanches.Controllers
{
    public class CartBuyController : Controller
    {
        private readonly ISnackRepository _repo;
        private readonly CartBuy _cartBuy;

        public CartBuyController(ISnackRepository repo, CartBuy cartBuy )
        {
            _repo = repo;
            _cartBuy = cartBuy;
        }
        public IActionResult Index()
        {
            var items = _cartBuy.GetCartBuyItems();
            _cartBuy.CartBuyItems = items;

            var cartbBuyViewModel = new CartBuyViewModel
            {
                cartBuy = _cartBuy,
                cartBuyTotal = _cartBuy.GetCartBuyTotal()
            };

            return View(cartbBuyViewModel);
        }

        public RedirectToActionResult AddItemCartBuy(int SnackId)
        {
            var snackSelected = _repo.Snacks.FirstOrDefault(s => s.Id == SnackId);

            if(snackSelected != null)
            {
                _cartBuy.AddCart(snackSelected, 1);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemCartBuy(int SnackId)
        {
            var snakeSelected = _repo.Snacks.FirstOrDefault(s => s.Id == SnackId);

            if(snakeSelected != null)
            {
                _cartBuy.RemoveCart(snakeSelected);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int SnackId)
        {
            var snack = _repo.Snacks.FirstOrDefault(s => s.Id == SnackId);
            if (snack == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(snack);
        }
    }
}