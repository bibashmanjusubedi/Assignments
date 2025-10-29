using Microsoft.EntityFrameworkCore;

namespace Assignment24
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=E:\AmnilTechnologies\Assignments\Assignment24\schoolSys.db");
    }
}
