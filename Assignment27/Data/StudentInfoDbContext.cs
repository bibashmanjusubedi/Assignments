using Microsoft.EntityFrameworkCore;
using Assignment27.Models;

namespace Assignment27.Data
{
    public class StudentInfoDbContext: DbContext
    {
        public StudentInfoDbContext(DbContextOptions<StudentInfoDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
