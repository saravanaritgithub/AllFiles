using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewProducts.Entity.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Amount is Required")]
        public decimal Amount { get; set; }
        public int ProductId { get; set; }//fk
        public Product Product { get; set; }
    }
}
