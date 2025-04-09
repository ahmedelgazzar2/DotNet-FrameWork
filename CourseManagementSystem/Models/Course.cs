using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [UniqueName]
        public string Name { get; set; }

        [Range(50,100)]
        public int Degree { get; set; }

        [Remote("CheckMinDeg","Course",AdditionalFields ="Degree"
                ,ErrorMessage ="MinDegree must be less than Degree")]
        public int MinDegree { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<CourseResult>? CourseResults { get; set; }
    }
}
