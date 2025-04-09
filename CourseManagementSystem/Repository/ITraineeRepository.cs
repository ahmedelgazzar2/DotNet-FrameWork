using CourseManagementSystem.Models;
using CourseManagementSystem.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public interface ITraineeRepository
    {
        List<Trainee> GetAll();
        Trainee GetById(int id);
        void Add(Trainee newTrainee);
        void Delete(int id);
        void Update(int id, Trainee newTrainee);
        void TraineeWithCourseResult(int id, TraineeWithCourseResultViewModel TraineeViewModel);
    }  
}
