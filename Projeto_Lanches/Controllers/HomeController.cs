using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Lanches.Repositories;
using Projeto_Lanches.ViewModel;
using System.Diagnostics;

namespace Projeto_Lanches.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnackRepository _repo;

        public HomeController(ISnackRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeviewModel
            {
                SnacksPrefirred = _repo.SnacksPreferred
            };
            
            return View(homeViewModel);
        }

        public IActionResult AcessDenied()
        {
            return View();
        }


    }
}
