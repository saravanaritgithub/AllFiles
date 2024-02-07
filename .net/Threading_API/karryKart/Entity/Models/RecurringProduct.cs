using Entites.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Recurring_Product
    {
        public int Id { get; set; }
        public int Cycle_Length { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public CyclePeriodEnum Period { get; set; }
        public int Total_Cycle { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

}