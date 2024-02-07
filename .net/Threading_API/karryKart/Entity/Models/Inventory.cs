using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public InventoryMethodEnum inventoryMethodEnum { get; set; }
        public int Stockquantity { get; set; }
        public WarehouseEnum warehouse { get; set; }
        public bool MultipleWarehouse { get; set; }
        public bool Displayavailability { get; set; }
        public int Minimumstockqty { get; set; }
        public Lowstockactivityenum lowstockactivityenum { get; set; }
        public int Notifyforqtybelow { get; set; }
        public BackordersEnum backordersbelow { get; set; }
        public bool Allowbackinstocksubscriptions { get; set; }
        public ProductavailabilityrangeEnum productavailabilityrange { get; set; }
        public int Minimumcartqty { get; set; }
        public int Maximumcartqty { get; set; }
        public string Allowedquantities { get; set; }
        public bool Notreturnable { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool Allowonlyexistingattributecombinations { get; set; }

    }
}