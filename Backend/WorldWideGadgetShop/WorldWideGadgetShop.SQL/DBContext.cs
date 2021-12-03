using Microsoft.EntityFrameworkCore;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.SQL
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}