using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Customers
{
    public class CustomerRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool FreeShipping { get; set; }
        public bool Taxexempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}