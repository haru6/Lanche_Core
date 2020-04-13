using System.ComponentModel.DataAnnotations;

namespace Projeto_Lanches.Models
{
    public class CartBuyItem
    {
        public int Id { get; set; }
        public Snack snack { get; set; }
        public int Amount { get; set; }
        [StringLength(200)]
        public string CartBuyId { get; set; }

    }
}
