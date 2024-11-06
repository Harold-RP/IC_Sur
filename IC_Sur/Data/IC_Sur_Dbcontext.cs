using IC_Sur.Models;
using Microsoft.EntityFrameworkCore;

namespace IC_Sur.Data
{
    public class IC_Sur_Dbcontext : DbContext
    {
        public IC_Sur_Dbcontext(DbContextOptions<IC_Sur_Dbcontext> options) : base(options)
        {

        }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderOrder> ProviderOrders { get; set; }
        public DbSet<StorageEntry> StorageEntries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assistance> Assistances { get; set; }
        public DbSet<EmployeePayment> EmployeePayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las tablas
            modelBuilder.Entity<Alert>().ToTable("Alerts");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Storage>().ToTable("Storage");
            modelBuilder.Entity<Provider>().ToTable("Providers");
            modelBuilder.Entity<ProviderOrder>().ToTable("ProviderOrders");
            modelBuilder.Entity<StorageEntry>().ToTable("StorageEntries");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Assistance>().ToTable("Assistances");
            modelBuilder.Entity<EmployeePayment>().ToTable("EmployeePayments");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Storage)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.StorageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Provider)
                .WithMany(pr => pr.Products)
                .HasForeignKey(p => p.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StorageEntry>()
                .HasOne(se => se.Product)
                .WithMany()
                .HasForeignKey(se => se.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StorageEntry>()
                .HasOne(se => se.Provider)
                .WithMany()
                .HasForeignKey(se => se.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StorageEntry>()
                .HasOne(se => se.Product)
                .WithMany()
                .HasForeignKey(se => se.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StorageEntry>()
                .HasOne(se => se.Provider)
                .WithMany()
                .HasForeignKey(se => se.ProviderId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}