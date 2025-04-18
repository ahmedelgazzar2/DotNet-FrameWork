using System.ComponentModel.DataAnnotations;

namespace CourseManagementSystem.ViewModel
{
    public class LoginUserViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
