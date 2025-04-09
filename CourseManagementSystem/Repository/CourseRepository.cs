using CourseManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ProjectEntities dbcontext;
        public CourseRepository(ProjectEntities dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<Course> GetAll()
        {
            List<Course> list = dbcontext.Courses.Include(c => c.Department).ToList();
            return list;
        }
        public Course GetById(int id)
        {
            Course course = dbcontext.Courses.FirstOrDefault(c => c.Id == id);
            return course;
        }
        public void Add(Course newCourse)
        {
            dbcontext.Courses.Add(newCourse);
            dbcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            Course course = GetById(id);
            dbcontext.Courses.Remove(course);
            dbcontext.SaveChanges();
        }
        public void Update(int id,Course newCourse)
        {
            Course oldCourse = dbcontext.Courses.FirstOrDefault(course => course.Id == id);
            oldCourse.Name         = newCourse.Name;
            oldCourse.Degree       = newCourse.Degree;
            oldCourse.MinDegree    = newCourse.MinDegree;
            oldCourse.DepartmentId = newCourse.DepartmentId;
            
            dbcontext.SaveChanges();
        }
        public List<Course> GetCoursesPerDepartments(int deptId)
        {
            List<Course> list = dbcontext.Courses.Where(c => c.DepartmentId == deptId).ToList();
            return list;
        }

    }
}
