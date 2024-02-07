using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewProducts.Entity.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int CartItemId { get; set; }
        [Required(ErrorMessage = "Grand Total Amount is Required")]
        public double GrandTotal { get; set; }
        public CartItem CartItem { get; set; }
    }
}
