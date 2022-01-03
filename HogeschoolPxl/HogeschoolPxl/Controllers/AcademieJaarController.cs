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
using Microsoft.AspNetCore.Authorization;
using HogeschoolPxl.Data.Default;

namespace HogeschoolPxl.Controllers
{
    [Authorize(Roles = Roles.AdminRole)]
    public class AcademieJaarController : Controller
    {
        private readonly IPxl iPxl;

        public AcademieJaarController(IPxl iPxl)
        {
            this.iPxl = iPxl;
        }

        // GET: AcademieJaar
        public async Task<IActionResult> Index()
        {
            return View(await iPxl.GetAcademieJaren());
        }

        // GET: AcademieJaar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var academieJaar = await iPxl.GetAcademieJaar(id);
            if (academieJaar == null)
            {
                return RedirecToNotFound(id);
            }

            return View(academieJaar);
        }

        // GET: AcademieJaar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademieJaar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcademieJaarId,StartDatum")] AcademieJaar academieJaar)
        {
            if (ModelState.IsValid)
            {
                await iPxl.AddAcademieJaar(academieJaar);
                return RedirectToAction(nameof(Index));
            }
            return View(academieJaar);
        }

        // GET: AcademieJaar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var academieJaar = await iPxl.GetAcademieJaar(id);
            if (academieJaar == null)
            {
                return RedirecToNotFound(id);
            }
            return View(academieJaar);
        }

        // POST: AcademieJaar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcademieJaarId,StartDatum")] AcademieJaar academieJaar)
        {
            if (id != academieJaar.AcademieJaarId)
            {
                return RedirecToNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await iPxl.UpdateAcademieJaar(academieJaar);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.AcademieJaarExists(academieJaar.AcademieJaarId))
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
            return View(academieJaar);
        }

        // GET: AcademieJaar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }
            var academieJaar = await iPxl.GetAcademieJaar(id);
            if (academieJaar == null)
            {
                return RedirecToNotFound(id);
            }

            return View(academieJaar);
        }

        // POST: AcademieJaar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await iPxl.DeleteAcademieJaar(id);
            return RedirectToAction(nameof(Index));
        }
        private RedirectToActionResult RedirecToNotFound()
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { categorie = "Academie Jaar" });
        }
        private RedirectToActionResult RedirecToNotFound(int? id = 0)
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { id, categorie = "Academie Jaar" });
        }
    }
}
