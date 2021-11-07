﻿using System;
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
    public class InschrijvingController : Controller
    {
        private readonly IPxl iPxl;

        public InschrijvingController(IPxl iPxl)
        {
            this.iPxl = iPxl;
        }

        // GET: Inschrijving
        public async Task<IActionResult> Index(string year)
        {
            if (year == null)
            {
                ViewBag.YearFilter = "nofilter";
                return View(await iPxl.GetInschrijvingen());
            }
            ViewBag.YearFilter = year;
            return View(await iPxl.GetInschrijvingenByYear(year));
        }

        // GET: Inschrijving/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await iPxl.GetInschrijving(id);
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
                Student std = await iPxl.GetStudent(inschrijving.StudentId);
                if(std == null) ModelState.AddModelError("", $"We could not find a student with id : {inschrijving.StudentId}");
                
                VakLector vakL = await iPxl.GetVakLectorByLector(inschrijving.VakLectorId);

                if (vakL == null) ModelState.AddModelError("", $"We could not find a vak lector with id : {inschrijving.VakLectorId}");

                AcademieJaar academie = await iPxl.GetAcademieJaar(inschrijving.AcademieJaarId);

                if (academie == null) ModelState.AddModelError("", $"We could not find an acadieme jaar with id : {inschrijving.AcademieJaarId}");

                if (std == null || vakL == null || academie ==null) return View(inschrijving);

                await iPxl.AddInschrijving(inschrijving);
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

            var inschrijving = await iPxl.GetInschrijving(id);
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
                    await iPxl.UpdateInschrijving(inschrijving);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.InschrijvingExists(inschrijving.InschrijvingId))
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

            var inschrijving = await iPxl.GetInschrijving(id);
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
            await iPxl.DeleteInschrijving(id);
            return RedirectToAction(nameof(Index));
        }
        private RedirectToActionResult RedirecToNotFound()
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { categorie = "Inschrijving" });
        }
        private RedirectToActionResult RedirecToNotFound(int? id = 0)
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { id, categorie = "Inschrijving" });
        }
    }
}
