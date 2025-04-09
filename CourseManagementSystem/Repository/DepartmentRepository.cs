using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ProjectEntities dbcontext;
        public DepartmentRepository(ProjectEntities dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<Department> GetAll()
        {
            List<Department> list = dbcontext.Departments.ToList();
            return list;
        }
        public Department GetById(int id)
        {
            Department dept = dbcontext.Departments.FirstOrDefault(d => d.Id == id);
            return dept;
        }
        public void Add(Department newDept)
        {
            dbcontext.Departments.Add(newDept);
            dbcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
            dbcontext.Departments.Remove(dept);
            dbcontext.SaveChanges();
        }
        public void Update(int id, Department newDept)
        {
            Department oldDept = dbcontext.Departments.FirstOrDefault(d => d.Id == id);
            oldDept.Name        = newDept.Name;
            oldDept.ManagerName = newDept.ManagerName;
            dbcontext.SaveChanges();
        }
    }
}
