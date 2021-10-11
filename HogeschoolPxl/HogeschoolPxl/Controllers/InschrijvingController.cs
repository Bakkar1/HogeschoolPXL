using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HogeschoolPxl.Data;
using HogeschoolPxl.Models;

namespace HogeschoolPxl.Controllers
{
    public class InschrijvingController : Controller
    {
        private readonly AppDbContext _context;

        public InschrijvingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Inschrijving
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inschrijvingen.ToListAsync());
        }

        // GET: Inschrijving/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .FirstOrDefaultAsync(m => m.InschrijvingId == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // GET: Inschrijving/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inschrijving/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InschrijvingId,StudentId,VakLectorId,AcademieJaarId")] Inschrijving inschrijving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inschrijving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inschrijving);
        }

        // GET: Inschrijving/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            if (inschrijving == null)
            {
                return NotFound();
            }
            return View(inschrijving);
        }

        // POST: Inschrijving/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InschrijvingId,StudentId,VakLectorId,AcademieJaarId")] Inschrijving inschrijving)
        {
            if (id != inschrijving.InschrijvingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inschrijving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InschrijvingExists(inschrijving.InschrijvingId))
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
            return View(inschrijving);
        }

        // GET: Inschrijving/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .FirstOrDefaultAsync(m => m.InschrijvingId == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // POST: Inschrijving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            _context.Inschrijvingen.Remove(inschrijving);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InschrijvingExists(int id)
        {
            return _context.Inschrijvingen.Any(e => e.InschrijvingId == id);
        }
    }
}
