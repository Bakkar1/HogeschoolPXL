using HogeschoolPxl.Data;
using HogeschoolPxl.Data.Default;
using HogeschoolPxl.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> singInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IPxl iPxl;

        public AccountController(UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> singInManager,
             RoleManager<IdentityRole> roleManager,
             IPxl iPxl)
        {
            this.userManager = userManager;
            this.singInManager = singInManager;
            this.iPxl = iPxl;
            this.roleManager = roleManager;
        }

        #region register
        public IActionResult Register()
        {
            ViewData["RoleId"] = iPxl.GetRoles();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser
                {
                    UserName = user.Email,
                    Email = user.Email,
                };
                var result = await userManager.CreateAsync(identityUser, user.Password);

                if (result.Succeeded)
                {
                    var role = await roleManager.FindByIdAsync(user.RoleId);
                    if (role != null)
                    {
                        await userManager.AddToRoleAsync(identityUser, role.Name);
                    }
                    await singInManager.SignInAsync(identityUser, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        #endregion
        #region LogOut
        public async Task<IActionResult> Logout()
        {
            await singInManager.SignOutAsync();
            return View("LogoutCompleted");
        }
        #endregion
        #region login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await userManager.FindByEmailAsync(model.Email);

                if (identityUser != null)
                {
                    var userName = identityUser.UserName;
                    var result = await singInManager.PasswordSignInAsync(
                         userName, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid Login Attempt");

            return View(model);
        }
        #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
