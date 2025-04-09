using CourseManagementSystem.Models;
using CourseManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepo;
        IDepartmentRepository departmentRepo;
        public CourseController(ICourseRepository courseRepo, IDepartmentRepository departmentRepo)
        {
            this.courseRepo = courseRepo;
            this.departmentRepo = departmentRepo;
            
        }
        public IActionResult Index()
        {
            List<Course> Courses = courseRepo.GetAll();
            return View(Courses);
        }

        public IActionResult New()
        {
            List<Department> departments = departmentRepo.GetAll();
            ViewBag.DropDowenList = departments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Course course)
        {
            if (ModelState.IsValid)
            {                 
                try
                {
                   courseRepo.Add(course);
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("DepartmentId", "Please Select a Department");
                }
            }
            List<Department> departments = departmentRepo.GetAll();
            ViewBag.DropDowenList = departments;
            return View("New",course);
        }

        public IActionResult Edit(int id)
        {
            Course course = courseRepo.GetById(id);
            List<Department> department = departmentRepo.GetAll();
            ViewBag.Department = department;
            return View(course);
        }

        public IActionResult SaveEdit(int id,Course course)
        {     
            if (ModelState.IsValid)
            {
                Course oldCource = courseRepo.GetById(id);
                if (oldCource != null)
                {
                    courseRepo.Update(id,course);
                    return RedirectToAction("Index");
                }
            }
            List<Department> departments = departmentRepo.GetAll();
            ViewBag.Department = departments;
            return View("Edit", course);
        }

        public IActionResult CheckMinDeg(int MinDegree,int Degree)
        {
            if (Degree >= MinDegree)
                return Json(true);
            return Json(false);
        }
    }
}
