using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IC_Sur.Data
{
    public class IC_Sur_Dbcontext: DbContext
    {
        public IC_Sur_Dbcontext(DbContextOptions<IC_Sur_Dbcontext> options) : base(options)
        {

        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Assistance> Assitances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<Role>().ToTable("Roles");
            //modelBuilder.Entity<Student>().ToTable("Students");
            //modelBuilder.Entity<Assistance>().ToTable("Assitance");
        }
    }
}
