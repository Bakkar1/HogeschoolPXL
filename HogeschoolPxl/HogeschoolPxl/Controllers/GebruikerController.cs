using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HogeschoolPxl.Data;
using HogeschoolPxl.Models;
using HogeschoolPxl.Helpers;
using Microsoft.AspNetCore.Hosting;
using HogeschoolPxl.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using HogeschoolPxl.Data.Default;
using Microsoft.AspNetCore.Identity;

namespace HogeschoolPxl.Controllers
{
    [Authorize(Roles = Roles.AdminRole)]
    public class GebruikerController : Controller
    {
        private readonly IPxl iPxl;
        private readonly IWebHostEnvironment HostingEnvironment;
        private readonly SignInManager<Gebruiker> singInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Gebruiker> userManager;

        public GebruikerController(IPxl iPxl, IWebHostEnvironment hostEnvironment, SignInManager<Gebruiker> singInManager,
             RoleManager<IdentityRole> roleManager, UserManager<Gebruiker> userManager)
        {
            this.iPxl = iPxl;
            this.HostingEnvironment = hostEnvironment;
            this.singInManager = singInManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            return View(await iPxl.GetGebruikers());

        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var gebruiker = await iPxl.GetGebruiker(id);
            if (gebruiker == null)
            {
                return RedirecToNotFound(1);
            }

            return View(gebruiker);
        }

        // GET: Gebruiker/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = iPxl.GetRoles();
            return View();
        }

        // POST: Gebruiker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GebruikerCreateViewModel model)
        {
            ViewData["RoleId"] = iPxl.GetRoles();
            if (ModelState.IsValid)
            {
                FotoHelper ft = new FotoHelper(HostingEnvironment);
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
                    var role = await roleManager.FindByIdAsync(model.RoleId);
                    if (role != null)
                    {
                        await userManager.AddToRoleAsync(identityUser, role.Name);
                    }
                    return RedirectToAction("index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        // GET: Gebruiker/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["RoleId"] = iPxl.GetRoles();
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var gebruiker = await iPxl.GetGebruiker(id);
            if (gebruiker == null)
            {
                return RedirecToNotFound();
            }
            GebruikerEditViewModel gebruikerEditViewModel = new GebruikerEditViewModel()
            {
                HelperId = gebruiker.Id,
                Naam = gebruiker.Naam,
                VoorNaam = gebruiker.VoorNaam,
                Email = gebruiker.Email,
                ExistingPhotoPath = gebruiker.ImageUrl,
                RoleId = iPxl.GetRoleName(gebruiker.Id)
            };
            return View(gebruikerEditViewModel);
        }

        // POST: Gebruiker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, GebruikerEditViewModel model)
        {
            ViewData["RoleId"] = iPxl.GetRoles();
            if (id != model.HelperId)
            {
                return RedirecToNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Gebruiker gebruiker = await iPxl.GetGebruiker(model.HelperId);

                    gebruiker.Naam = model.Naam;
                    gebruiker.VoorNaam = model.VoorNaam;
                    gebruiker.Email = model.Email;
                    gebruiker.UserName = model.Email;
                    gebruiker.ImageUrl = model.ExistingPhotoPath;

                    if (model.Photo != null)
                    {
                        if (model.ExistingPhotoPath != null)
                        {
                            //delete existing photo
                            string filePath = Path.Combine(HostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                            System.IO.File.Delete(filePath);
                        }
                        FotoHelper ft = new FotoHelper(HostingEnvironment);
                        gebruiker.ImageUrl = ft.ProcessUploadedFile(model.Photo);
                    }
                    await iPxl.UpdateGebruiker(gebruiker);
                    
                    await UpdateRoles(gebruiker, model.RoleId);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.GebruikerExists(model.Id))
                    {
                        return RedirecToNotFound(1);
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return View(model);
        }

        public async Task UpdateRoles(Gebruiker identityUser, string roleId)
        {
            iPxl.DeleteOldRoles(identityUser.Id);

            var role = await roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                await userManager.AddToRoleAsync(identityUser, role.Name);
            }
        }

        // GET: Gebruiker/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var gebruiker = await iPxl.GetGebruiker(id);
            if (gebruiker == null)
            {
                return RedirecToNotFound();
            }

            return View(gebruiker);
        }

        // POST: Gebruiker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Gebruiker gebruiker = await iPxl.DeleteGebruiker(id);

            if (gebruiker.ImageUrl != null)
            {
                //delete existing photo
                string filePath = Path.Combine(HostingEnvironment.WebRootPath, "images", gebruiker.ImageUrl);
                System.IO.File.Delete(filePath);
            }
            return RedirectToAction(nameof(Index));
        }
        private RedirectToActionResult RedirecToNotFound()
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { categorie = "Gebruiker" });
        }
        private RedirectToActionResult RedirecToNotFound(int? id = 0)
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { id, categorie = "Gebruiker" });
        }
    }
}
