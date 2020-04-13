using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Lanches.Models
{
    public class Snack
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string DescriptionShort { get; set; }
        [StringLength(255)]
        public string DescriptionDetailed { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        [StringLength(200)]
        public string ImageURL { get; set; }
        [StringLength(200)]
        public string ImageThumbnaiURL { get; set; }
        public bool Preferred { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category category { get; set; }
    }
}
