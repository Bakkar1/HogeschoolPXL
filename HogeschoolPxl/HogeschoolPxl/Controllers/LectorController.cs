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
using HogeschoolPxl.Helpers;

namespace HogeschoolPxl.Controllers
{
    public class LectorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPxl iPxl;

        public LectorController(AppDbContext context, IPxl iPxl)
        {
            _context = context;
            this.iPxl = iPxl;
        }

        // GET: Lector
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lectoren.Include(l => l.Gebruiker).ToListAsync());
        }

        // GET: Lector/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lector = await _context.Lectoren
                .FirstOrDefaultAsync(m => m.LectorId == id);
            if (lector == null)
            {
                return NotFound();
            }

            return View(lector);
        }

        // GET: Lector/Create
        public async Task<IActionResult> Create()
        {
            LectorCreateViewModel model = new LectorCreateViewModel()
            {
                Gebruikers = await iPxl.GetGebruikers()
            };
            return View(model);
        }

        // POST: Lector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LectorCreateViewModel model)
        {
            model.Gebruikers = await iPxl.GetGebruikers();
            if (ModelState.IsValid)
            {
                var CheckLector = _context.Lectoren.Where(l => l.GebruikerId == model.GebruikerId).FirstOrDefault();
                if(CheckLector != null)
                {
                    ModelState.AddModelError("", $"Lector with gebruiker id {model.GebruikerId} alredy exist");
                    return View(model);
                }
                Lector lector = new Lector()
                {
                    GebruikerId = model.GebruikerId
                };
                _context.Add(lector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Lector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lector = await _context.Lectoren.FindAsync(id);
            if (lector == null)
            {
                return NotFound();
            }
            return View(lector);
        }

        // POST: Lector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LectorId,GebruikerId")] Lector lector)
        {
            if (id != lector.LectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectorExists(lector.LectorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lector);
        }

        // GET: Lector/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lector = await _context.Lectoren
                .FirstOrDefaultAsync(m => m.LectorId == id);
            if (lector == null)
            {
                return NotFound();
            }

            return View(lector);
        }

        // POST: Lector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lector = await _context.Lectoren.FindAsync(id);
            _context.Lectoren.Remove(lector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectorExists(int id)
        {
            return _context.Lectoren.Any(e => e.LectorId == id);
        }
        private RedirectToActionResult RedirecToNotFound()
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { categorie = "Lector" });
        }
        private RedirectToActionResult RedirecToNotFound(int? id = 0)
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { id, categorie = "Lector" });
        }
    }
}
