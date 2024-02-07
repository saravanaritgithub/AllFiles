﻿using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class GiftCard
    {
        public int Id { get; set; }
        public bool Giftcard { get; set; }
        public GiftcardtypeEnum giftcardtype { get; set; }
        public double Overriddengiftcardamount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}