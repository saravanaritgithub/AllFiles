using Microsoft.EntityFrameworkCore;
using ProductKart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProductKart.Entity.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

  => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SC4BHGR\\MSSQLSERVER01;Initial Catalog=ProductKart;Integrated Security=True;TrustServerCertificate=True;");
    }
}