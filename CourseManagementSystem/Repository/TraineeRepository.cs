using CourseManagementSystem.Models;
using CourseManagementSystem.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public class TraineeRepository: ITraineeRepository
    {
        ProjectEntities dbcontext;
        ICourseResultRepository courseResultRepo;
        public TraineeRepository(ICourseResultRepository courseResultRepo, ProjectEntities dbcontext)
        {
            this.courseResultRepo = courseResultRepo;
            this.dbcontext = dbcontext;
        }
        public List<Trainee> GetAll()
        {
            List<Trainee> list = dbcontext.Trainee.Include(c => c.Department).ToList();
            return list;
        }
        public Trainee GetById(int id)
        {
            Trainee trainee = dbcontext.Trainee.FirstOrDefault(t => t.Id == id);
            return trainee;
        }
        public void Add(Trainee newTrainee)
        {           
            dbcontext.Trainee.Add(newTrainee);
            dbcontext.SaveChanges();
            courseResultRepo.SetTraineeResults(newTrainee.Id, newTrainee.DepartmentId);
            dbcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            Trainee trainee = GetById(id);
            dbcontext.Trainee.Remove(trainee);
            dbcontext.SaveChanges();
        }
        public void Update(int id, Trainee newTrainee)
        {
            Trainee oldTrainee = dbcontext.Trainee.FirstOrDefault(trainee => trainee.Id == id);
            oldTrainee.Name         = newTrainee.Name;
            oldTrainee.Img          = newTrainee.Img;
            oldTrainee.Address      = newTrainee.Address;
            //oldTrainee.Grade        = newTrainee.Grade;
            oldTrainee.DepartmentId = newTrainee.DepartmentId;

            dbcontext.SaveChanges();
        }
        public void TraineeWithCourseResult(int id,TraineeWithCourseResultViewModel TraineeViewModel)
        {
            Trainee trainee =GetById(id);
            CourseResult courseresult = courseResultRepo.GetTraineeResults(id);           

            //declear data to view model
            TraineeViewModel.Id = trainee.Id;
            TraineeViewModel.Name = trainee.Name;
            TraineeViewModel.Course = courseresult.Course.Name;
            TraineeViewModel.CourseResult = courseresult.Degree;
            TraineeViewModel.color = "Red";

            if (TraineeViewModel.CourseResult >= courseresult.Course.MinDegree)
                TraineeViewModel.color = "Green";
        }
    }
}
