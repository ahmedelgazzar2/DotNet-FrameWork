using CourseManagementSystem.Models;
using CourseManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementSystem.Controllers
{
    public class InstructorController : Controller
    {
        IinstructorRepository InsRepo;
        ICourseRepository CourseRepo;
        IDepartmentRepository DeptRepo;

        public InstructorController(IinstructorRepository InsRepo, ICourseRepository CourseRepo, IDepartmentRepository DeptRepo)
        {
            this.InsRepo = InsRepo;
            this.CourseRepo = CourseRepo;
            this.DeptRepo = DeptRepo;
        }
        public IActionResult Index()
        {
            List<Instructor> InsList = InsRepo.GetAll();

            return View(InsList);
        }

        public IActionResult Details(int id)
        {
            Instructor Ins = InsRepo.GetById(id);
            return View(Ins);
        }

        [HttpGet]
        public IActionResult New()
        {
            List<Department> department = DeptRepo.GetAll();
            List<Course> course = CourseRepo.GetAll();
            ViewBag.DeptList = department;
            ViewBag.CourseList = course;
            return View();
        }

        [HttpPost]
        public IActionResult SaveNew(Instructor NewIns)
        {
            if (NewIns.Name != null)
            {
                InsRepo.Add(NewIns);
                return RedirectToAction("Index");
            }
            return View("New",NewIns);
        }

        public IActionResult Edit(int id)
        { 
            Instructor instructor = InsRepo.GetById(id);
            List<Department> department = DeptRepo.GetAll();
            List<Course> course = CourseRepo.GetAll();
            ViewBag.DeptList = department;
            ViewBag.CourseList = course;
            return View(instructor);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id,Instructor EditIns)
        {
            if (EditIns.Name != null)
            {
                Instructor oldIns = InsRepo.GetById(id);
                if (oldIns != null)
                {
                    InsRepo.Update(id, EditIns);
                    return RedirectToAction("Index");
                }
            }
            return View("Edit", EditIns);
        }

        public IActionResult GetPartialData(int id)
        {
            Instructor instructor = InsRepo.GetById(id);
            return PartialView("_InstructorDetailsPartial", instructor);
        }
    }
}
