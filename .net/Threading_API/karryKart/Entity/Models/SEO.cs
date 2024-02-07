using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class SEO
    {
        public int Id { get; set; }
        public string? searchenginefriendlypagename {  get; set; }
        public string? MetaTitle {  get; set; }
        public string? MetaKeywords {  get; set; }
        public string? MetaDescription { get; set;}
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
