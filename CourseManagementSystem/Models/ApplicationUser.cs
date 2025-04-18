using Microsoft.AspNetCore.Identity;

namespace CourseManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
