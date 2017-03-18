using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunitySite.Models;
using CommunitySite.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunitySite.Controllers
{
    public class LoginController : Controller
    {
        private UserManager<ParkMember> userManager;
        private SignInManager<ParkMember> signInManager;

        public LoginController(UserManager<ParkMember> userMgr, SignInManager<ParkMember> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [HttpGet]
        public IActionResult Register()
        {
           
            return View(new ParkMember());
        }

        [HttpPost]
        public async Task<IActionResult> Register(ParkMember pm)
        {
            if (ModelState.IsValid)
            {
                ParkMember user = new ParkMember
                {
                    FirstName = pm.FirstName,
                    LastName = pm.LastName,
                    Email = pm.Email,
                    DogName = pm.DogName,
                    DogBreed = pm.DogBreed,
                    UserName = pm.UserName,
                    ForumAlias = pm.ForumAlias

                };
                IdentityResult result = await userManager.CreateAsync(user, pm.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Forum", "Forum");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(pm);
        }
        public ViewResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ParkMember user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    //signs out anyone that is currently logged in
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                user, loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError(nameof(LoginModel.UserName),
                "Invalid user or password");
            }
            return View(loginModel);
        }


        public async Task<RedirectResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("Login");
        }

        
    }
}

