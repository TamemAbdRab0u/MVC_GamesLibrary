using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyGamesLibrary.ViewModel;

namespace MyGamesLibrary.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> rolemanger;
        public RoleController(RoleManager<IdentityRole> rolemanger)
        {
            this.rolemanger = rolemanger;
        }

        public IActionResult AddRole()
        {
            return View();
        }

        public async Task<IActionResult> SaveRole(RoleViewModel Role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Role.Name;

                IdentityResult result = await rolemanger.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Content("Role Added Succefully");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            
            return RedirectToAction("AddRole",Role);
        }
    }
}
