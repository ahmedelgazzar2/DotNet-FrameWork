using CourseManagementSystem.Models;
using CourseManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository deptRepo;
        ICourseRepository courseRepo ;
        public DepartmentController(IDepartmentRepository deptRepo, ICourseRepository courseRepo)
        {
            this.deptRepo = deptRepo;
            this.courseRepo = courseRepo;
        }
        public IActionResult Index()
        {
             List<Department> department = deptRepo.GetAll();
            return View(department);
        }

        public IActionResult GetCoursesPerDepartment(int deptId)
        {
            List<Course> courses = courseRepo.GetCoursesPerDepartments(deptId);
            return Json(courses);
        }
    }
}
