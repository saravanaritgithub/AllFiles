using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Repo
{
    public class StudentRepo : IStudentRepasitary
    {
        private readonly StudentContext _studentContext;
        public StudentRepo(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public async Task<IEnumerable<Student>> GetStudent()
        {
            return await _studentContext.Students.ToListAsync();
        }
        public async Task<Student> GetStudentById(int studentId)
        {
            return await _studentContext.Students.FirstOrDefaultAsync(e => e.Id == studentId);
        }
        public async Task<Student> AddStudent(Student student)
        {
            var result = await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await _studentContext.Students
                .FirstOrDefaultAsync(e => e.Id == student.Id);

            if (result != null)
            {
                result.Name= student.Name;
                result.Address= student.Address;
                result.City= student.City;
                result.dateTime=student.dateTime;
                result.PhoneNumber= student.PhoneNumber;
                await _studentContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task DeleteStudent(int studentId)
        {
            var result = await _studentContext.Students
                .FirstOrDefaultAsync(e => e.Id == studentId);
            if (result != null)
            {
                _studentContext.Students.Remove(result);
                await _studentContext.SaveChangesAsync();
            }
        }
    }
}
