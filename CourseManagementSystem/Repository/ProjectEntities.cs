using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public class ProjectEntities : DbContext
    {

        public ProjectEntities() : base()
        {

        }

        public ProjectEntities(DbContextOptions Options) : base(Options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = .;Initial Catalog=CourseManagemrntSystem;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }




    }
}
