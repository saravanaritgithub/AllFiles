using Entites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class DownloadableProduct

    {
        public int Id { get; set; }
        public bool UsedownloadURL { get; set; }
        public string DownloadURL { get; set; }
        public bool Unlimiteddownloads { get; set; }
        public int NoofDays { get; set; }
        public DownloadEnum Downloadactivationtype { get; set; }
        public bool Hasuseragreement { get; set; }
        public bool Hassampledownloadfile { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}