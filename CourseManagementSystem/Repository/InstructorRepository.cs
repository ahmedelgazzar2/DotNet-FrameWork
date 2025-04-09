using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public class InstructorRepository: IinstructorRepository
    {
        ProjectEntities dbcontext;
        public InstructorRepository(ProjectEntities dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<Instructor> GetAll()
        {
            List<Instructor> list = dbcontext.Instructors.ToList();
            return list;
        }
        public Instructor GetById(int id)
        {
            Instructor instructor = dbcontext.Instructors.FirstOrDefault(i => i.Id == id);
            return instructor;
        }
        public void Add(Instructor newIns)
        {
            dbcontext.Instructors.Add(newIns);
            dbcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            Instructor instructor = GetById(id);
            dbcontext.Instructors.Remove(instructor);
            dbcontext.SaveChanges();
        }
        public void Update(int id, Instructor newIns)
        {
            Instructor oldIns = dbcontext.Instructors.FirstOrDefault(i => i.Id == id);
            oldIns.Name         = newIns.Name;
            oldIns.Img          = newIns.Img;
            oldIns.Salary       = newIns.Salary;
            oldIns.DepartmentId = newIns.DepartmentId;
            oldIns.CourseId     = newIns.CourseId;
            dbcontext.SaveChanges();
        }
        public List<Course> GetCoursesPerDepartments(int deptId)
        {
            List<Course> list = dbcontext.Courses.Where(c => c.DepartmentId == deptId).ToList();
            return list;
        }


    }
}
