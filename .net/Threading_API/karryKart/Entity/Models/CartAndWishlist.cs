using Entites.Enums;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class CartAndWishlist
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public ShoppingCartTypeEnum shoppingCartTypeEnum { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public WarehouseEnum StoreName { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
