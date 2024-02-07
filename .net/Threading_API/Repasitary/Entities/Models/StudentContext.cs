using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
        public class StudentContext : DbContext
        {
            public StudentContext() { }
            public StudentContext(DbContextOptions<StudentContext> options) : base(options)
            {
            }
            public virtual DbSet<Student> Students { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SC4BHGR\\MSSQLSERVER01;Initial Catalog=School;Integrated Security=True;TrustServerCertificate=True;");
    }
    
}
