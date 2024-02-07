using Entity.Models;
using Microsoft.EntityFrameworkCore;
namespace ConsoleToDB.Data
{
    public class DataContext : DbContext
    {
        public readonly object Categories;
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SC4BHGR\\MSSQLSERVER01;Initial Catalog=NewFlipkart;Integrated Security=True;TrustServerCertificate=True;");
    }

}