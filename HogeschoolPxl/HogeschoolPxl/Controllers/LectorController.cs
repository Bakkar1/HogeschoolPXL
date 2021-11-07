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
        private readonly IPxl iPxl;

        public LectorController(IPxl iPxl)
        {
            this.iPxl = iPxl;
        }

        // GET: Lector
        public async Task<IActionResult> Index()
        {
            return View(await iPxl.GetLectoren());
        }

        // GET: Lector/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var lector = await iPxl.GetLector(id);
            if (lector == null)
            {
                return RedirecToNotFound(id);
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
                var CheckLector = await iPxl.CheckLector(model.GebruikerId);
                if (CheckLector != null)
                {
                    ModelState.AddModelError("", $"Lector with gebruiker id {model.GebruikerId} alredy exist");
                    return View(model);
                }
                Lector lector = new Lector()
                {
                    GebruikerId = model.GebruikerId
                };
                await iPxl.AddLector(lector);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Lector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var lector = await iPxl.GetLector(id);
            if (lector == null)
            {
                return RedirecToNotFound(id);
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
                return RedirecToNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await iPxl.UpdateLector(lector);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.LectorExists(lector.LectorId))
                    {
                        return RedirecToNotFound(lector.LectorId);
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
                return RedirecToNotFound();
            }
            var lector = await iPxl.GetLector(id);
            if (lector == null)
            {
                return RedirecToNotFound(id);
            }

            return View(lector);
        }

        // POST: Lector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await iPxl.DeleteLector(id);
            return RedirectToAction(nameof(Index));
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
