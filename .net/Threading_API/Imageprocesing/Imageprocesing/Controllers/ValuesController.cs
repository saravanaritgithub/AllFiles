using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Imageprocesing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ValuesController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost]
        public Task<Joining> Post([FromForm] FileUpload objFile)
        {
            Joining obj = new Joining();
            obj.ListStudent = new List<Student>();
            obj.fileAPI = new FileUpload();
            try
            {
                obj.ListStudent = new List<Student>()
            {
                new Student()
                {
                    studentName = objFile.students,
                    studentID = 1,
                }
            };
                //List<FileUpload> list = JsonConvert.DeserializeObject<List<FileUpload>>(objFile.FileUploads);
                //obj.ListStudent = list;
                obj.fileAPI.ImgID = objFile.ImgID;
                obj.fileAPI.ImgName = "\\Upload\\" + objFile.files.FileName;
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\Upload"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + "\\Upload\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.ContentRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(filestream);
                        filestream.Flush();
                        //  return "\\Upload\\" + objFile.files.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(obj);
        }
    }
}
