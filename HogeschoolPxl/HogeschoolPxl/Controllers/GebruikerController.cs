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

namespace HogeschoolPxl.Controllers
{
    public class GebruikerController : Controller
    {
        private readonly IPxl iPxl;
        private readonly IWebHostEnvironment HostingEnvironment;

        public GebruikerController(IPxl iPxl, IWebHostEnvironment hostEnvironment)
        {
            this.iPxl = iPxl;
            this.HostingEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            return View(await iPxl.GetGebruikers());

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var gebruiker = await iPxl.GetGebruiker(id);
            if (gebruiker == null)
            {
                return RedirecToNotFound(id);
            }

            return View(gebruiker);
        }

        // GET: Gebruiker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gebruiker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GebruikerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                FotoHelper ft = new FotoHelper(HostingEnvironment);
                string uniqueFileName = ft.ProcessUploadedFile(model);
                Gebruiker gebruiker = new Gebruiker()
                {
                    GebruikerId = model.GebruikerId,
                    Naam = model.Naam,
                    VoorNaam = model.VoorNaam,
                    Email = model.Email,
                    ImageUrl = uniqueFileName
                };
                await iPxl.AddGebruiker(gebruiker);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Gebruiker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var gebruiker = await iPxl.GetGebruiker(id);
            if (gebruiker == null)
            {
                return RedirecToNotFound(id);
            }
            GebruikerEditViewModel gebruikerEditViewModel = new GebruikerEditViewModel()
            {
                HelperId = gebruiker.GebruikerId,
                Naam = gebruiker.Naam,
                VoorNaam = gebruiker.VoorNaam,
                Email = gebruiker.Email,
                ExistingPhotoPath = gebruiker.ImageUrl
            };
            return View(gebruikerEditViewModel);
        }

        // POST: Gebruiker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GebruikerEditViewModel model)
        {
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
                        gebruiker.ImageUrl = ft.ProcessUploadedFile(model);
                    }
                    await iPxl.UpdateGebruiker(gebruiker);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.GebruikerExists(model.GebruikerId))
                    {
                        return RedirecToNotFound(model.GebruikerId);
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return View(model);
        }

        // GET: Gebruiker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var gebruiker = await iPxl.GetGebruiker(id);
            if (gebruiker == null)
            {
                return RedirecToNotFound(id);
            }

            return View(gebruiker);
        }

        // POST: Gebruiker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Gebruiker gebruiker = await iPxl.DeleteGebruiker(id);

            //delete existing photo
            string filePath = Path.Combine(HostingEnvironment.WebRootPath, "images", gebruiker.ImageUrl);
            System.IO.File.Delete(filePath);
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
