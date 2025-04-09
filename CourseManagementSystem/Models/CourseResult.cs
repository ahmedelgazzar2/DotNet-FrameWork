using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementSystem.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public double Degree { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Trainee Trainee { get; set; }
        public virtual Course Course { get; set; }

    }
}
