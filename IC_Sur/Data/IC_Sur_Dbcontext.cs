using IC_Sur.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IC_Sur.Data
{
    public class IC_Sur_Dbcontext: DbContext
    {
        public IC_Sur_Dbcontext(DbContextOptions<IC_Sur_Dbcontext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Storage>().ToTable("Storage");
            modelBuilder.Entity<Provider>().ToTable("Providers");
        }
    }
}
