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
        private readonly AppDbContext _context;
        private readonly IPxl _iPxl;
        private readonly IWebHostEnvironment hostEnvironment;

        public GebruikerController(AppDbContext context, IPxl iPxl, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _iPxl = iPxl;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: Gebruiker
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Gebruikers.ToListAsync());

        //}

        public async Task<IActionResult> Index()
        {
            return View(await _iPxl.GetGebruikersAsync());

        }
        //public IActionResult Index()
        //{
        //    return View(_iPxl.GetGebruikers());

        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                
                return RedirectToAction("NotFoundEr", "Error", new {categorie = "Gebruiker" });
            }

            var gebruiker = await _context.Gebruikers
                .FirstOrDefaultAsync(m => m.GebruikerId == id);
            if (gebruiker == null)
            {
                return RedirectToAction("NotFoundEr", "Error", new { id = id , categorie = "Gebruiker"});
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
                FotoHelper ft = new FotoHelper(hostEnvironment);
                string uniqueFileName = ft.ProcessUploadedFile(model);
                Gebruiker gebruiker = new Gebruiker()
                {
                    GebruikerId = model.GebruikerId,
                    Naam = model.Naam,
                    VoorNaam = model.VoorNaam,
                    Email = model.Email,
                    ImageUrl = uniqueFileName
                };
                _context.Add(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Gebruiker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruikers.FindAsync(id);
            if (gebruiker == null)
            {
                return NotFound();
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
        public async Task<IActionResult> Edit(GebruikerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Gebruiker gebruiker = _context.Gebruikers.Find(model.HelperId);

                gebruiker.Naam = model.Naam;
                gebruiker.VoorNaam = model.VoorNaam;
                gebruiker.Email = model.Email;
                gebruiker.ImageUrl = model.ExistingPhotoPath;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        //delete existing photo
                        string filePath = Path.Combine(hostEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    FotoHelper ft = new FotoHelper(hostEnvironment);
                    gebruiker.ImageUrl = ft.ProcessUploadedFile(model);
                }
                _context.Gebruikers.Update(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
            //if (id != gebruiker.GebruikerId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(gebruiker);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!GebruikerExists(gebruiker.GebruikerId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(gebruiker);
        }

        // GET: Gebruiker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruikers
                .FirstOrDefaultAsync(m => m.GebruikerId == id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(gebruiker);
        }

        // POST: Gebruiker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gebruiker = await _context.Gebruikers.FindAsync(id);
            _context.Gebruikers.Remove(gebruiker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GebruikerExists(int id)
        {
            return _context.Gebruikers.Any(e => e.GebruikerId == id);
        }
    }
}
