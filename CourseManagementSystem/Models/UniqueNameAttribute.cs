using CourseManagementSystem.Repository;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementSystem.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ProjectEntities context = new ProjectEntities();
            string name = value.ToString();
            Course CourseFromClient = (Course) validationContext.ObjectInstance;
            int Dept_Id = CourseFromClient.DepartmentId;
            Course course = context.Courses.FirstOrDefault(c => c.Name == name && c.DepartmentId == Dept_Id);
            if(course == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Course already found -- Course Name must be unique in one Department");
            }
        }
    }
}
