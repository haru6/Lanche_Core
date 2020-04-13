using Microsoft.EntityFrameworkCore;
using Projeto_Lanches.Models;

namespace Projeto_Lanches.Database
{
    public class SnacksContext : DbContext
    {
        public SnacksContext(DbContextOptions<SnacksContext> options) : base(options)
        {

        }
        public DbSet<Snack> Snacks  { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartBuyItem> CartBuyItens { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }
    }   
}
