﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Cart
    {
        public int CartId{ get; set; }
        public int Quantity { get; set; }
        public double amount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
