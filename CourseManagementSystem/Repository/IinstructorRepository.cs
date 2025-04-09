using CourseManagementSystem.Models;

namespace CourseManagementSystem.Repository
{
    public interface IinstructorRepository
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
        void Add(Instructor newIns);
        void Delete(int id);
        void Update(int id, Instructor newIns);
        List<Course> GetCoursesPerDepartments(int deptId);
       
    }
}
