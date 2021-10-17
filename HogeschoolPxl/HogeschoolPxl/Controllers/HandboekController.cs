using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HogeschoolPxl.Data;
using HogeschoolPxl.Models;
using HogeschoolPxl.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace HogeschoolPxl.Controllers
{

    public class HandboekController : Controller
    {
        private readonly AppDbContext _context;

        public IWebHostEnvironment hostingEnvironment { get; }

        public HandboekController(AppDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Handboek
        public async Task<IActionResult> Index()
        {
            return View(await _context.handboeken.ToListAsync());
        }

        // GET: Handboek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handboek = await _context.handboeken
                .FirstOrDefaultAsync(m => m.HandboekId == id);
            if (handboek == null)
            {
                return NotFound();
            }

            return View(handboek);
        }

        // GET: Handboek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Handboek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HandboekCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Handboek handboek = new Handboek()
                {
                    Title = model.Title,
                    KostPrijs = model.KostPrijs,
                    UitGifteDatum = model.UitGifteDatum,
                    Afbeelding = uniqueFileName,
                };
                _context.Add(handboek);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        private string ProcessUploadedFile(HandboekCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                //upload de image file to the server (images folder)
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fs);
                }
            }
            return uniqueFileName;
        }

        // GET: Handboek/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handboek =  _context.handboeken.Find(id);
            if (handboek == null)
            {
                return NotFound();
            }
            HandboekEditViewModel handboekEditViewModel = new HandboekEditViewModel()
            {
                HelperId = handboek.HandboekId,
                Title = handboek.Title,
                KostPrijs = handboek.KostPrijs,
                UitGifteDatum = handboek.UitGifteDatum,
                ExistingPhotoPath = handboek.Afbeelding
            };
            return View(handboekEditViewModel);
        }

        // POST: Handboek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HandboekEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Handboek handboek = _context.handboeken.Find(model.HelperId);

                handboek.Title = model.Title;
                handboek.KostPrijs = model.KostPrijs;
                handboek.UitGifteDatum = model.UitGifteDatum;
                handboek.Afbeelding = model.ExistingPhotoPath;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        //delete existing photo
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    handboek.Afbeelding = ProcessUploadedFile(model);
                }
                _context.handboeken.Update(handboek);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Handboek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handboek = await _context.handboeken
                .FirstOrDefaultAsync(m => m.HandboekId == id);
            if (handboek == null)
            {
                return NotFound();
            }

            return View(handboek);
        }

        // POST: Handboek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var handboek = await _context.handboeken.FindAsync(id);
            _context.handboeken.Remove(handboek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HandboekExists(int id)
        {
            return _context.handboeken.Any(e => e.HandboekId == id);
        }
    }
}
