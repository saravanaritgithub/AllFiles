using Entites.Models;
using Entities.Models;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost]
        public Task<ParentCategory_imgupl> Post([FromForm] FileUploads pro)
        {
            ParentCategory_imgupl parentCategory_Imgupl = new ParentCategory_imgupl();
            parentCategory_Imgupl.fileUploads = new FileUploads();
            parentCategory_Imgupl.parent_CatgList = new List<ParentCategory>();
            try
            {
                parentCategory_Imgupl.parent_CatgList = new List<ParentCategory>() { new ParentCategory() { Parent_Category_Name = pro.Parent, Id = pro.ImgId } };

                parentCategory_Imgupl.fileUploads.ImgId = pro.ImgId;
                parentCategory_Imgupl.fileUploads.Imgname = "\\Uploads\\" + pro.files.FileName;
                if (pro.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\Uploads"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + "\\Uploads\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.ContentRootPath + "\\Uploads\\" + pro.files.FileName))
                    {
                        pro.files.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(parentCategory_Imgupl);
        }
    }
}