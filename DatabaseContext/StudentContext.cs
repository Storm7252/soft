using Microsoft.EntityFrameworkCore;
using Softst.Models;

namespace Softst.DatabaseContext
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions options):base(options)
        {

        }
        public  DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
