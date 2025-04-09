using CourseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Repository
{
    public class CourseResultRepository:ICourseResultRepository
    {
        ProjectEntities dbcontext;
        public CourseResultRepository(ProjectEntities dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public CourseResult GetTraineeResults(int id)
        {
            CourseResult courseresult = dbcontext.CourseResults.Include(c => c.Course).FirstOrDefault(c => c.TraineeId == id);
            return courseresult;
        }

    }
}
