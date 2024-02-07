using Entities.Models;
using System.Numerics;

namespace Contracts
{
    public interface IStudentRepasitary
    {
        Task<IEnumerable<Student>> GetStudent();
        Task<Student> GetStudentById(int studentId);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student player);
        Task DeleteStudent(int studentId);

    }
}
