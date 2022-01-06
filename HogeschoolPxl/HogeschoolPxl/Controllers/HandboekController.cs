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
using HogeschoolPxl.Helpers;
using Microsoft.AspNetCore.Authorization;
using HogeschoolPxl.Data.Default;

namespace HogeschoolPxl.Controllers
{
    [Authorize(Roles = Roles.StudentRole + "," + Roles.AdminRole + "," + Roles.LectorRole)]
    public class HandboekController : Controller
    {
        private readonly IPxl iPxl;

        public IWebHostEnvironment HostingEnvironment { get; }

        public HandboekController(IWebHostEnvironment HostingEnvironment, IPxl iPxl)
        {
            this.HostingEnvironment = HostingEnvironment;
            this.iPxl = iPxl;
        }

        // GET: Handboek
        public async Task<IActionResult> Index()
        {
            return View(await iPxl.GetHandboeken());
        }
        public async Task<IActionResult> LectorHandboeken(string userName)
        {
            var CurrentGberuiker = await iPxl.GetGebruikerByName(userName);
            var lectorId = 0;
            if (CurrentGberuiker.lectoren.FirstOrDefault() != null)
            {
                lectorId = CurrentGberuiker.lectoren.FirstOrDefault().LectorId;
            }

            return View("Index", await iPxl.GetLectorHandboeken(lectorId));
        }

        // GET: Handboek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var handboek = await iPxl.GetHandboek(id);
            if (handboek == null)
            {
                return RedirecToNotFound(id);
            }

            return View(handboek);
        }

        // GET: Handboek/Create
        [Authorize(Roles = Roles.AdminRole)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Handboek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Create(HandboekCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                FotoHelper ft = new FotoHelper(HostingEnvironment);
                string uniqueFileName = ft.ProcessUploadedFile(model);
                Handboek handboek = new Handboek()
                {
                    Title = model.Title,
                    KostPrijs = model.KostPrijs,
                    UitGifteDatum = model.UitGifteDatum,
                    Afbeelding = uniqueFileName,
                };
                await iPxl.AddHandboek(handboek);
                return RedirectToAction("index");
            }
            return View();
        }

        // GET: Handboek/Edit/5
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var handboek = await iPxl.GetHandboek(id);
            if (handboek == null)
            {
                return RedirecToNotFound(id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Edit(HandboekEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Handboek handboek = await iPxl.GetHandboek(model.HelperId);

                handboek.Title = model.Title;
                handboek.KostPrijs = model.KostPrijs;
                handboek.UitGifteDatum = model.UitGifteDatum;
                handboek.Afbeelding = model.ExistingPhotoPath;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        //delete existing photo
                        string filePath = Path.Combine(HostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    FotoHelper ft = new FotoHelper(HostingEnvironment);
                    handboek.Afbeelding = ft.ProcessUploadedFile(model);
                }
                await iPxl.UpdateHandboek(handboek);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Handboek/Delete/5
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                RedirecToNotFound();
            }

            var handboek = await iPxl.GetHandboek(id);
            if (handboek == null)
            {
                return RedirecToNotFound(id);
            }

            return View(handboek);
        }

        // POST: Handboek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Handboek handboek = await iPxl.DeleteHandboek(id);

            //delete existing photo
            if (handboek.Afbeelding != null)
            {
                string filePath = Path.Combine(HostingEnvironment.WebRootPath, "images", handboek.Afbeelding);
                System.IO.File.Delete(filePath);
            }

            return RedirectToAction(nameof(Index));
        }
        private RedirectToActionResult RedirecToNotFound()
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { categorie = "Handboek" });
        }
        private RedirectToActionResult RedirecToNotFound(int? id = 0)
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { id, categorie = "Handboek" });
        }
    }
}
