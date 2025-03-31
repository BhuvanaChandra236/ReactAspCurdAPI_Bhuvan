using Microsoft.EntityFrameworkCore;

namespace ReactASPCurdAPI.Models
{
    public class StudentDbContext : DbContext
    {

        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KUSUPATI\\SQLEXPRESS;Initial Catalog=REACTASPCURDAPI;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
