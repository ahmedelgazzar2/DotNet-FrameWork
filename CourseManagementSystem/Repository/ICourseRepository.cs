using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();

        Course GetById(int id);

        void Add(Course newCourse);

        void Delete(int id);

        void Update(int id, Course newCourse);

        List<Course> GetCoursesPerDepartments(int deptId);
        
    }
}
