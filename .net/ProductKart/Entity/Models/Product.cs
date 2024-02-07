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
    public class Product
    {
        [Key]
        public int ProductId { get; set; } = 1;
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int AvaliableQuantity { get; set; }



    }
}
