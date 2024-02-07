using Entites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public bool ShippingEnabled { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool FreeShipping { get; set; }
        public bool Shippingseperately { get; set; }
        public double AdditionalShippingCharges { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public DeliveryDateEnum deliveryDate { get; set; }
        public DateTime created_at { get; set; }
        public string Created_By { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
