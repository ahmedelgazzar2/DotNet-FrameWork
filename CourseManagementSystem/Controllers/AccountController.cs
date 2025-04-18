using CourseManagementSystem.Models;
using CourseManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userMangaer;
        SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userMangaer = userManager;
            this.signInManager = signInManager;
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                //check database
                ApplicationUser? userModel = await userMangaer.FindByEmailAsync(loginUser.Email);
                if (userModel != null)//this email already registered
                {
                    bool found = await userMangaer.CheckPasswordAsync(userModel, loginUser.Password);
                    if (found)//password is true...create cookie
                    {
                        await signInManager.SignInAsync(userModel, loginUser.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "wrong Password");
                    }
                }
                else //this email isn't found in database (wrong email or need to register)
                {
                    ModelState.AddModelError("Email", "wrong Email..please check your Email or Register");
                }

            }
            return View(loginUser);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                //mapping from ViewModel to Model
                ApplicationUser user = new ApplicationUser();
                user = newUser.MappingVmToApp(newUser, user);
                IdentityResult CreateResult = await userMangaer.CreateAsync(user, newUser.Password);
                

                if (CreateResult.Succeeded)
                {
                    //Create Cookie
                    await signInManager.SignInAsync(user,false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in CreateResult.Errors)
                    {
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

            }
            return View("Register", newUser);                 
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Delete(RegisterUserViewModel userVm)
        {
            string Email = userVm.Email;
            ApplicationUser? user = await userMangaer.FindByEmailAsync(Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email is not Found");
            }
            else
            {
                IdentityResult result = await userMangaer.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", "Email is not Found");
                    }
                }
            }
            return View(userVm);
        }
    }
}
