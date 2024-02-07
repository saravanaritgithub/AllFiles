namespace Imageprocesing
{
    public class FileUpload
    { 
        public int ImgID { get; set; }
        public string? students { get; set; }
        public IFormFile? files { get; set; }
        public string? ImgName { get; set; }
    }
    public class Student
    {
        public int studentID { get; set; }
        public string? studentName { get; set; }
    }
    public class Joining
    {
        public FileUpload? fileAPI { get; set; }
        public Student? Student { get; set; }
        public List<Student>? ListStudent { get; set; }
    }
}
