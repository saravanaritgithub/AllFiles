using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ParentCategory_imageupload
    {
        public FileUploads _fileAPI { get; set; }
        public ParentCategory _ParentCategory { get; set; }
        public List<ParentCategory> ListParentCategory { get; set; }
    }
}