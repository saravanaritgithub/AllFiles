using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Repasitary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepasitary _studentRepasitary;
        public StudentController(IStudentRepasitary studentRepasitary)
        {
            _studentRepasitary = studentRepasitary;
        }

        [HttpGet("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudent()
        {
            var stud = await _studentRepasitary.GetStudent();
            return stud;
        }

        [HttpGet("GetStudentByID")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var stud = await _studentRepasitary.GetStudentById(id);
            return stud;
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            Student stud = new Student();
            if (student != null)
            {

                stud = await _studentRepasitary.AddStudent(student);
            }
            return stud;
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<Student>> UpdateStudent(Student student)
        {
            var update = await _studentRepasitary.UpdateStudent(student);
            return update;
        }

        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentRepasitary.DeleteStudent(id);
            return NoContent();
        }
                // GET: api/<StudentController>
                [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
