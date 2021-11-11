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

namespace HogeschoolPxl.Controllers
{
    public class VakLectorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPxl iPxl;

        public VakLectorController(AppDbContext context, IPxl iPxl)
        {
            _context = context;
            this.iPxl = iPxl;
        }

        // GET: VakLector
        public async Task<IActionResult> Index()
        {
            //return View(await _context.VakLectoren
            //    .Include(vl => vl.Lector.Gebruiker)
            //    .Include(vl => vl.Vak.Handboek)
            //    .ToListAsync());
            return View(await iPxl.GetVakLectoren());
        }

        // GET: VakLector/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            //var vakLector = await _context.VakLectoren
            //    .FirstOrDefaultAsync(m => m.VakLectorId == id);
            var vakLector = await iPxl.GetVakLector(id);
            if (vakLector == null)
            {
                return RedirecToNotFound(id);
            }

            return View(vakLector);
        }

        // GET: VakLector/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VakLector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VakLectorId,LectorId,GebruikerId,VakId")] VakLector vakLector)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(vakLector);
                //await _context.SaveChangesAsync();
                await iPxl.AddVakLector(vakLector);
                return RedirectToAction(nameof(Index));
            }
            return View(vakLector);
        }

        // GET: VakLector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            //var vakLector = await _context.VakLectoren.FindAsync(id);
            var vakLector = await iPxl.GetVakLector(id);
            if (vakLector == null)
            {
                return RedirecToNotFound(id);
            }
            return View(vakLector);
        }

        // POST: VakLector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VakLectorId,LectorId,GebruikerId")] VakLector vakLector)
        {
            if (id != vakLector.VakLectorId)
            {
                return RedirecToNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(vakLector);
                    //await _context.SaveChangesAsync();
                    await iPxl.UpdateVakLector(vakLector);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.VakLectorExists(vakLector.VakLectorId))
                    {
                        return RedirecToNotFound(id);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vakLector);
        }

        // GET: VakLector/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            //var vakLector = await _context.VakLectoren
            //    .FirstOrDefaultAsync(m => m.VakLectorId == id);
            var vakLector = await iPxl.GetVakLector(id);
            if (vakLector == null)
            {
                return RedirecToNotFound(id);
            }

            return View(vakLector);
        }

        // POST: VakLector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var vakLector = await _context.VakLectoren.FindAsync(id);
            //_context.VakLectoren.Remove(vakLector);
            //await _context.SaveChangesAsync();
            await iPxl.DeleteVakLector(id);
            return RedirectToAction(nameof(Index));
        }

        private RedirectToActionResult RedirecToNotFound()
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { categorie = "VakLector" });
        }
        private RedirectToActionResult RedirecToNotFound(int? id = 0)
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { id, categorie = "VakLector" });
        }
    }
}
