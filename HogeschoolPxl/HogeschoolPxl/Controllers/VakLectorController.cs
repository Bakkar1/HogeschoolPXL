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
using HogeschoolPxl.ViewModels;

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
            return View(await iPxl.GetVakLectoren());
        }

        // GET: VakLector/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var vakLector = await iPxl.GetVakLector(id);
            if (vakLector == null)
            {
                return RedirecToNotFound(id);
            }

            return View(vakLector);
        }

        // GET: VakLector/Create
        public async Task<IActionResult> Create()
        {
            VakLectorCreateViewModel model = new VakLectorCreateViewModel()
            {
                Lectoren = await iPxl.GetLectoren(),
                Vakken = await iPxl.GetVakken()
            };
            return View(model);
        }

        // POST: VakLector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VakLectorId,LectorId,GebruikerId,VakId")] VakLectorCreateViewModel model)
        {
            model.Lectoren = await iPxl.GetLectoren();
            model.Vakken = await iPxl.GetVakken();
            if (ModelState.IsValid)
            {
                await iPxl.AddVakLector((VakLector)model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: VakLector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var vakLector = await iPxl.GetVakLector(id);
            if (vakLector == null)
            {
                return RedirecToNotFound(id);
            }
            VakLectorEditViewModel model = new VakLectorEditViewModel()
            {
                VakLectorId = vakLector.VakLectorId,
                LectorId = vakLector.LectorId,
                VakId = vakLector.VakId,
                Vak = vakLector.Vak,
                Lector = vakLector.Lector,
                Lectoren = await iPxl.GetLectoren(),
                Vakken = await iPxl.GetVakken()
            };
            return View(model);
        }

        // POST: VakLector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VakLectorId,LectorId,GebruikerId,VakId")] VakLectorEditViewModel model)
        {
            model.Lectoren = await iPxl.GetLectoren();
            model.Vakken = await iPxl.GetVakken();
            if (id != model.VakLectorId)
            {
                return RedirecToNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await iPxl.UpdateVakLector((VakLector)model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.VakLectorExists(model.VakLectorId))
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
            return View(model);
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
