using Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.dbContext
{
    public class NegoSudDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Fournisseur> Fournisseurs{ get; set; }
        public DbSet<Product> Products { get; set; }

        public NegoSudDBContext(DbContextOptions<NegoSudDBContext> options):base(options)
        {
            
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users");
                user.Property(x => x.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Family>(user =>
            {
                user.ToTable("Families");
                user.Property(x => x.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Fournisseur>(user =>
            {
                user.ToTable("Fournissers");
                user.Property(x => x.Id).ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<Product>(user =>
            {
                user.ToTable("Products");
                user.Property(x => x.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
