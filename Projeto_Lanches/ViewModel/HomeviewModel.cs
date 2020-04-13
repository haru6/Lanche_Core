using Projeto_Lanches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.ViewModel
{
    public class HomeviewModel
    {
        public IEnumerable<Snack> SnacksPrefirred { get; set; }
    }
}
