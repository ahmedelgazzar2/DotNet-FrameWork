using CourseManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CourseManagementSystem.ViewModel
{
    public class RegisterUserViewModel
    {       
        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ApplicationUser MappingVmToApp(RegisterUserViewModel userVm,ApplicationUser appUser)
        {
            appUser.UserName     = userVm.Name;
            appUser.Email        = userVm.Email;
            appUser.PasswordHash = userVm.Password;
            appUser.PhoneNumber  = userVm.PhoneNumber;
            appUser.Address      = userVm.Address;  
            return appUser;
        }
    }
}
