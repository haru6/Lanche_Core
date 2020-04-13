using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Lanches.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string CateoryName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public List<Snack> Snacks { get; set; }

    }
}
