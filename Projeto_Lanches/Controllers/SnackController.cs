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
    public class SnackController : Controller
    {
        private readonly ICategoryRepository _crepo;
        private readonly ISnackRepository _srepo;

        public SnackController(ICategoryRepository crepo, ISnackRepository srepo)
        {
            _crepo = crepo;
            _srepo = srepo;
        }
        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Snack> snacks;
            string categoryCurrent = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                snacks = _srepo.Snacks.OrderBy(l => l.Id);
                category = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", _category, StringComparison.OrdinalIgnoreCase))
                {
                    snacks = _srepo.Snacks.Where(c => c.category.CateoryName.Equals("Normal")).OrderBy(c=>c.Name);
                }
                else
                {
                    snacks = _srepo.Snacks.Where(c => c.category.CateoryName.Equals("Natural")).OrderBy(c => c.Name);
                }

                categoryCurrent = _category;
            }

            var SnackList = new SnackListViewModel();
            SnackList.Snacks = snacks;
            SnackList.CategoryCurrent = categoryCurrent; 
            return View(SnackList);
        }

        public IActionResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Snack> snacks;
            string _categoryCurrent = string.Empty;

            if (String.IsNullOrEmpty(_searchString))
            {
                snacks = _srepo.Snacks.OrderBy(s => s.Id);
            }
            else
            {
                snacks = _srepo.Snacks.Where(s => s.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Snack/List.cshtml", new SnackListViewModel { Snacks = snacks, CategoryCurrent = "Todos os lanches" });
        }
    }
}