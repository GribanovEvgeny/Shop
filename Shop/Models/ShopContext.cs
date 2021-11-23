using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
	public class ShopContext : DbContext
	{
		public DbSet<Order> Orders { get; set; }

        public ShopContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ShopDB;Trusted_Connection=True;");
        }
    }
}
