using System.Data.Entity;

namespace StudentWebApi.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
            : base("StudentDbContext")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}