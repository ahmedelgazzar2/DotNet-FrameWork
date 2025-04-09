using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public interface ICourseResultRepository
    {
        public CourseResult GetTraineeResults(int id);
        
    }
}
