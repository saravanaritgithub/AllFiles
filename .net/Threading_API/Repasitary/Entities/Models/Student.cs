using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Student
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime dateTime { get; set; }
            public long PhoneNumber { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
    }
}
