using CourseManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public class ProjectEntities : IdentityDbContext<ApplicationUser>
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
