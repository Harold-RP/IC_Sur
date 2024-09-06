using IC_Sur.Models;
using Microsoft.EntityFrameworkCore;

namespace IC_Sur.Data
{
    public class IC_Sur_Dbcontext : DbContext
    {
        public IC_Sur_Dbcontext(DbContextOptions<IC_Sur_Dbcontext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<StorageEntry> StorageEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las tablas
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Storage>().ToTable("Storage");
            modelBuilder.Entity<Provider>().ToTable("Providers");
            modelBuilder.Entity<StorageEntry>().ToTable("StorageEntries");

            // Relación de muchos a uno entre Product y Storage
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Storage)   // Un producto tiene un solo almacén
                .WithMany(s => s.Products) // Un almacén puede tener varios productos
                .HasForeignKey(p => p.StorageId) // Llave foránea en Product que refiere a Storage
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento de eliminación en cascada

            // Relación de muchos a uno entre Product y Provider
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Provider)  // Un producto tiene un proveedor
                .WithMany(pr => pr.Products) // Un proveedor puede proveer varios productos
                .HasForeignKey(p => p.ProviderId) // Llave foránea en Product que refiere a Provider
                .OnDelete(DeleteBehavior.Restrict); // No se elimina en cascada cuando se elimina un proveedor

            // Relación de muchos a uno entre StorageEntry y Product
            modelBuilder.Entity<StorageEntry>()
                .HasOne(se => se.Product)  // Un StorageEntry tiene un solo producto
                .WithMany() // Un producto puede tener múltiples entradas de almacén
                .HasForeignKey(se => se.ProductId)  // Llave foránea en StorageEntry que refiere a Product
                .OnDelete(DeleteBehavior.Cascade);  // Eliminación en cascada

            // Relación de muchos a uno entre StorageEntry y Provider
            modelBuilder.Entity<StorageEntry>()
                .HasOne(se => se.Provider) // Un StorageEntry tiene un solo proveedor
                .WithMany() // Un proveedor puede tener múltiples entradas de almacén
                .HasForeignKey(se => se.ProviderId) // Llave foránea en StorageEntry que refiere a Provider
                .OnDelete(DeleteBehavior.Cascade);  // Eliminación en cascada


        }
    }
}
