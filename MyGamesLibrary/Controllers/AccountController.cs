using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyGamesLibrary.Models;
using MyGamesLibrary.ViewModel;
using System.Security.Claims;

namespace MyGamesLibrary.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> usermanger;
        SignInManager<ApplicationUser> signinmanager;
        public AccountController(UserManager<ApplicationUser> usermanger, SignInManager<ApplicationUser> signinmanager)
        {
            this.usermanger = usermanger;
            this.signinmanager = signinmanager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterViewModel registermodel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = registermodel.Name;
                user.Email = registermodel.Email;
                user.PasswordHash = registermodel.Password;

                IdentityResult result = await usermanger.CreateAsync(user,registermodel.Password);
                if (result.Succeeded)
                {
                    
                    await usermanger.AddToRoleAsync(user, registermodel.RoleName);

                    await signinmanager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View("Register", registermodel);
        }

        public async Task<IActionResult> Logout()
        {
            await signinmanager.SignOutAsync();
            return View("Login");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginViewModel loginmodel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await usermanger.FindByNameAsync(loginmodel.UserName);
                if (user != null)
                {
                    bool found = await usermanger.CheckPasswordAsync(user, loginmodel.Password);
                    if (found == true)
                    {
                        // Cookie
                        await signinmanager.SignInAsync(user, loginmodel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName or Password Wrong.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password Wrong.");
                }
            }

            return View("Login", loginmodel);
        }



        public IActionResult ForgetPassword()
        {
            return View();
        }

        public async Task<IActionResult> SaveForgetPassword(ForgetPasswordViewModel forget)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await usermanger.FindByNameAsync(forget.Name);
                if (user != null)
                {
                    // Create New Password
                    string NewPassword = usermanger.PasswordHasher.HashPassword(user,forget.Password);
                    user.PasswordHash = NewPassword;

                    await usermanger.UpdateAsync(user);
                    return View("Login");
                }

                else
                {
                    ModelState.AddModelError("", "This User Does Not Exist");
                }
            }

            return View("ForgetPassword", forget);
        }
    }
}
