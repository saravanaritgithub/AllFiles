using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Tax
    {
        public int Id { get; set; }
        public string TaxCode { get; set; }
        public double SGSTPercentage { get; set; }
        public double CGSTPercentage { get; set; }
        public DateTime created_at { get; set; }
        public string Created_By { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}