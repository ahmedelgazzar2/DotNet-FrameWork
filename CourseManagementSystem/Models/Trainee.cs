using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementSystem.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Address { get; set; }
        //public double? Grade { get; set; }


        [ForeignKey("Department")]
        public int DepartmentId { get; set; }


        public virtual Department Department { get; set; }     
        public virtual List<CourseResult>? CourseResults { get; set; }

    }
}
