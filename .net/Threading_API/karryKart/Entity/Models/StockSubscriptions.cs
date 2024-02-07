using Entites.Enums;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class StockSubscriptions
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public WarehouseEnum StoreName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime SubscribedOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}