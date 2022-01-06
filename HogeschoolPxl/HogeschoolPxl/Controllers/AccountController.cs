using HogeschoolPxl.Data;
using HogeschoolPxl.Data.Default;
using HogeschoolPxl.Helpers;
using HogeschoolPxl.Models;
using HogeschoolPxl.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly UserManager<Gebruiker> userManager;
        private readonly SignInManager<Gebruiker> singInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IPxl iPxl;
        private readonly IWebHostEnvironment HostEnvironment;

        public AccountController(UserManager<Gebruiker> userManager,
             SignInManager<Gebruiker> singInManager,
             RoleManager<IdentityRole> roleManager,
             IPxl iPxl,
             IWebHostEnvironment hostEnvironment)
        {
            this.userManager = userManager;
            this.singInManager = singInManager;
            this.iPxl = iPxl;
            this.HostEnvironment = hostEnvironment;
            this.roleManager = roleManager;
        }

        #region register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                FotoHelper ft = new FotoHelper(HostEnvironment);
                string uniqueFileName = ft.ProcessUploadedFile(model.Photo);

                var identityUser = new Gebruiker()
                {
                    Naam = model.Naam,
                    VoorNaam = model.VoorNaam,
                    Email = model.Email,
                    UserName = model.Email,
                    ImageUrl = uniqueFileName,
                };

                var result = await userManager.CreateAsync(identityUser, model.Password);

                if (result.Succeeded)
                {
                    await singInManager.SignInAsync(identityUser, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
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
