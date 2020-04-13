using Microsoft.AspNetCore.Mvc;
using Projeto_Lanches.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _repo;

        public CategoryMenu(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _repo.Categories.OrderBy(c => c.CateoryName);

            return View(categories);
        }
    }
}
