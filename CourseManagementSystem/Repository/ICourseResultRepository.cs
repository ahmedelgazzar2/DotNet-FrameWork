using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public interface ICourseResultRepository
    {
        CourseResult GetTraineeResults(int id);

        void SetTraineeResults(int Traineeid, int DeptId);

    }
}
