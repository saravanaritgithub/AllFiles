using Microsoft.EntityFrameworkCore;
using NewProducts.Entity.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace NewProducts.Entity.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext() { }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .Property(e => e.Amount)
                .HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);

        }
        public virtual DbSet<User> UserTable { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        //public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ProductPattern;Integrated Security=True;TrustServerCertificate=True;");
    }
}
