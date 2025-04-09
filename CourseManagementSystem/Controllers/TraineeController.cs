using CourseManagementSystem.Models;
using CourseManagementSystem.Repository;
using CourseManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Controllers
{
    public class TraineeController : Controller
    {
        ITraineeRepository TraineeRepo;
        ICourseResultRepository CourseResultRepo;
        IDepartmentRepository DepartmentRepo;
       
        public TraineeController(ITraineeRepository TraineeRepo, ICourseResultRepository CourseResultRepo, IDepartmentRepository DepartmentRepo)
        {
            this.TraineeRepo = TraineeRepo;
            this.CourseResultRepo = CourseResultRepo;
            this.DepartmentRepo = DepartmentRepo;
        }
       
        public IActionResult Index()
        {
            List<Trainee> trainees = TraineeRepo.GetAll();
            return View(trainees);
        }
        public IActionResult Details(int id)
        {
            //getting data from database
            //TraineeWithCourseResultViewModel TraineeViewModel = new TraineeWithCourseResultViewModel();
            //CourseResult courseResult = CourseResultRepo.GetTraineeResults(id);
            //if (courseResult != null)
            //{
            //    //declear data to view model
            //    TraineeRepo.TraineeWithCourseResult(id, TraineeViewModel);
            //    return View(TraineeViewModel);
            //}
            Trainee trainee = TraineeRepo.GetById(id);
            return View(trainee);
        }

        [HttpGet]
        public IActionResult New(int id)
        {
            List<Department> department = DepartmentRepo.GetAll();
            ViewBag.DeptList = department;
            return View();
        }

        [HttpPost]
        public IActionResult SaveNew(int id,Trainee NewTrainee)
        {
            if (NewTrainee != null)
            {
                TraineeRepo.Add(NewTrainee);
                RedirectToAction("Index");
            }
            return View("New",NewTrainee);
        }
    }
}
