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

        public void SetTraineeResults(int id,int CourseId)
        {
            CourseResult courseresult = new CourseResult();
            courseresult.TraineeId = id;
            courseresult.CourseId = CourseId;
            courseresult.Degree = 0;
            dbcontext.CourseResults.Add(courseresult);
            dbcontext.SaveChanges();
        }

    }
}
