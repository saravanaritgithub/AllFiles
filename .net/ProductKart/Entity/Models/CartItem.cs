using ProductKart.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKart.Entity.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int Amount { get; set; }
        public int TotalAmount { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Userid { get; set; }
        public User User { get; set; }

    }
}
