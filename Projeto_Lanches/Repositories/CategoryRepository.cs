using Projeto_Lanches.Database;
using Projeto_Lanches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SnacksContext _context;

        public CategoryRepository(SnacksContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories;
    }
}
