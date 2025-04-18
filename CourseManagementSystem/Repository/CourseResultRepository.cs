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

        public void SetTraineeResults(int Traineeid,int DeptId)
        {
            CourseResult courseresult = new CourseResult();
            List<Course> Courses = dbcontext.Courses.Where(c=> c.DepartmentId == DeptId).ToList();
            courseresult.TraineeId = Traineeid;
            courseresult.Degree = -1; //default degree
            foreach (Course course in Courses)
            {
                courseresult.CourseId = course.Id;               
                dbcontext.CourseResults.Add(courseresult);
                dbcontext.SaveChanges();
            }
        }

    }
}
