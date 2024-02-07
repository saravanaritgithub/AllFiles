using Entites.Models;
using Entities.Models.Customers;
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
        public virtual DbSet<ParentCategory> ParentCategory { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<SEO> SEO { get; set; }
        public virtual DbSet<DownloadableProduct> DownloadableProduct { get; set; }
        public virtual DbSet<GiftCard> GiftCard { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Recurring_Product> Recurring_Product { get; set; }
        public virtual DbSet<Rental> Rental { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<RewardPoint> RewardPoint { get; set; }
        public virtual DbSet<CustomerRole> CustomerRole { get; set; }
        public virtual DbSet<OnlineCustomer> OnlineCustomer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<StockSubscriptions> StockSubscriptions { get; set; }
        public virtual DbSet<CartAndWishlist> CartAndWishlist { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SC4BHGR\\MSSQLSERVER01;Initial Catalog=KarryKart;Integrated Security=True;TrustServerCertificate=True;");
    }
}