using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lanches.Models
{
    [Table("RequestDetail")]
    public class RequestDetail
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int SnackId { get; set; }
        public int Ammount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual Snack Snack { get; set; }
        public virtual Request Request { get; set; }
    }
}
