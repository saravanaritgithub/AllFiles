using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entity.Models
{
public class FileUploads

    {
        public int ImgId { get; set; }
        public string Parent { get; set; }
        public IFormFile files { get; set; }
        public string Imgname { get; set; }
        public int ParentCategoryID { get; set; }
        public ParentCategory ParentCatgs { get; set; }

    }
}
