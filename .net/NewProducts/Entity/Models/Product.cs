using System.ComponentModel.DataAnnotations;

namespace NewProducts.Entity.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } = 1;
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        public string ProductName { get; set; }
        public double SellingPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
