using Projeto_Lanches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.Repositories
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }
        IEnumerable<Snack> SnacksPreferred { get; }
        Snack GetSnackById(int id);
    }
}
