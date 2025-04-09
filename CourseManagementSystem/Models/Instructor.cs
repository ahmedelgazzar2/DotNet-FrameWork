using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Salary { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Course Course { get; set; }

    }
}
