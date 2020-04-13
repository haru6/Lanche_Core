using Microsoft.EntityFrameworkCore;
using Projeto_Lanches.Database;
using Projeto_Lanches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly SnacksContext _context;

        public SnackRepository(SnacksContext context)
        {
            _context = context;
        }
        public IEnumerable<Snack> Snacks => _context.Snacks.Include(s => s.category);

        public IEnumerable<Snack> SnacksPreferred => _context.Snacks.Where(s => s.Preferred == true).Include(s => s.category);

        public Snack GetSnackById(int id)
        {
           return _context.Snacks.FirstOrDefault(s => s.Id == id);
        }
    }
}
