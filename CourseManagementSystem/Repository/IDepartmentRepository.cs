using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        
        Department GetById(int id);
        
        void Add(Department newDept);
        
        void Delete(int id);
        
        void Update(int id, Department newDept);
        
    }
}
