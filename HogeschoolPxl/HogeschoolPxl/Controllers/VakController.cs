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
using HogeschoolPxl.Data.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Identity;

namespace HogeschoolPxl.Controllers
{
    [Authorize(Roles = Roles.StudentRole + "," + Roles.AdminRole + "," + Roles.LectorRole)]
    public class VakController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPxl iPxl;
        private readonly UserManager<Gebruiker> userManager;

        public VakController(AppDbContext context, IPxl iPxl, UserManager<Gebruiker> userManager)
        {
            _context = context;
            this.iPxl = iPxl;
            this.userManager = userManager;
        }

        // GET: Vak
        public async Task<IActionResult> Index()
        {
            return View(await iPxl.GetVakken());
        }
        public async Task<IActionResult> LectorVakken(string userName)
        {
            var CurrentGberuiker = await iPxl.GetGebruikerByName(userName);
            var lectorId = 0;
            if (CurrentGberuiker.lectoren.FirstOrDefault() != null)
            {
                lectorId = CurrentGberuiker.lectoren.FirstOrDefault().LectorId;
            }
            return View("Index", await iPxl.GetLectorVakken(lectorId));
        }
        // GET: Vak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var vak = await iPxl.GetVak(id);
            if (vak == null)
            {
                return RedirecToNotFound(id);
            }

            return View(vak);
        }

        // GET: Vak/Create
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Create()
        {
            VakCreateViewModel model = new VakCreateViewModel()
            {
                Handboeken = await iPxl.GetHandboeken()
            };
            return View(model);
        }

        // POST: Vak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Create([Bind("VakId,VakNaam,Studiepunten,HandboekId")] VakCreateViewModel model)
        {
            model.Handboeken = await iPxl.GetHandboeken();
            if (ModelState.IsValid)
            {
                if (iPxl.GetHandboek(model.HandboekId) == null)
                {
                    ModelState.AddModelError("", $"Handboek With id {model.HandboekId} does not exist !");
                    return View();
                }
                Vak vak = new Vak()
                {
                    VakNaam = model.VakNaam,
                    Studiepunten = model.Studiepunten,
                    HandboekId = model.HandboekId
                };
                await iPxl.AddVak(vak);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Vak/Edit/5
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var vak = await iPxl.GetVak(id);
            if (vak == null)
            {
                return RedirecToNotFound(id);
            }

            VakEditViewModel model = new VakEditViewModel()
            {
                VakId = vak.VakId,
                VakNaam = vak.VakNaam,
                Studiepunten = vak.Studiepunten,
                HandboekId = vak.HandboekId,
                Handboeken = await iPxl.GetHandboeken()
            };
            return View(model);
        }

        // POST: Vak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Edit(int id, [Bind("VakId,VakNaam,Studiepunten,HandboekId")] VakEditViewModel model)
        {
            model.Handboeken = await iPxl.GetHandboeken();
            if (id != model.VakId)
            {
                return RedirecToNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await iPxl.UpdateVak((Vak)model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.VakExists(model.VakId))
                    {
                        return RedirecToNotFound(model.VakId);
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

        // GET: Vak/Delete/5
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var vak = await iPxl.GetVak(id);
            if (vak == null)
            {
                return RedirecToNotFound(id);
            }

            return View(vak);
        }

        // POST: Vak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await iPxl.DeleteVak(id);
            return RedirectToAction(nameof(Index));
        }
        private RedirectToActionResult RedirecToNotFound()
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { categorie = "Vak" });
        }
        private RedirectToActionResult RedirecToNotFound(int? id = 0)
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { id, categorie = "Vak" });
        }
    }
}
