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
using Microsoft.AspNetCore.Authorization;
using HogeschoolPxl.Data.Default;

namespace HogeschoolPxl.Controllers
{
    [Authorize(Roles = Roles.AdminRole + "," + Roles.LectorRole)]
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPxl iPxl;

        public StudentController(AppDbContext context, IPxl iPxl)
        {
            _context = context;
            this.iPxl = iPxl;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await iPxl.GetStudenten());
        }
        
        public async Task<IActionResult> LectorStudenten(string userName)
        {
            var CurrentGberuiker = await iPxl.GetGebruikerByName(userName);
            var lectorId = 0;
            if(CurrentGberuiker.lectoren.FirstOrDefault() != null)
            {
                lectorId = CurrentGberuiker.lectoren.FirstOrDefault().LectorId;
            }
            var model = await iPxl.GetLectorStudenten(lectorId);
            return View("Index", model);
        } 

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var student = await iPxl.GetStudent(id);
            if (student == null)
            {
                return RedirecToNotFound(id);
            }

            StudentDetailsViewModel model = new StudentDetailsViewModel()
            {
                Student = student,
                Inschrijvingen = await iPxl.GetStudentOverzicht(student.StudentId)
            };
            return View(model);
        }

        public async Task<IActionResult> GetPartial(string searchName)
        {
            if (string.IsNullOrEmpty(searchName))
            {
                return PartialView("StudentCard", await iPxl.GetStudenten());
            }
            var studenten = await iPxl.GetStudentenByName(searchName);

            return PartialView("StudentCard", studenten);
        }

        // GET: Student/Create
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Create()
        {
            StudentCreateViewModel model = new StudentCreateViewModel()
            {
                Gebruikers = await iPxl.GetGebruikers()
            };
            return View(model);
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Create([Bind("StudentId,Id")] StudentCreateViewModel model)
        {
            model.Gebruikers = await iPxl.GetGebruikers();
            if (ModelState.IsValid)
            {
                bool isStudent = await iPxl.CheckStudent(model.Id);
                if (isStudent)
                {
                    ModelState.AddModelError("", $"De Student is alredy exist");
                    return View(model);
                }
                var CheckLector = await iPxl.CheckLector(model.Id);
                if (CheckLector != null)
                {
                    ModelState.AddModelError("", $"Gebruiker is a Lector");
                    return View(model);
                }

                Student student = new Student()
                {
                    Id = model.Id
                };
                await iPxl.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Student/Edit/5
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var student = await iPxl.GetStudent(id);
            if (student == null)
            {
                return RedirecToNotFound(id);
            }
            StudentEditViewModel model = new StudentEditViewModel()
            {
                StudentId = student.StudentId,
                Id = student.Id,
                Gebruiker = student.Gebruiker,
                Gebruikers = await iPxl.GetGebruikers()
            };
            return View(model);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Id")] StudentEditViewModel model)
        {
            model.Gebruikers = await iPxl.GetGebruikers();
            if (id != model.StudentId)
            {
                return RedirecToNotFound();
            }

            bool isStudent = await iPxl.CheckStudent(model.Id);
            if (isStudent)
            {
                ModelState.AddModelError("", $"De Student  is alredy exist");
                return View(model);
            }
            var CheckLector = await iPxl.CheckLector(model.Id);
            if (CheckLector != null)
            {
                ModelState.AddModelError("", $"De lector is a Lector");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await iPxl.UpdateStudent((Student)model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.StudentExists(model.StudentId))
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

        // GET: Student/Delete/5
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            var student = await iPxl.GetStudent(id);
            if (student == null)
            {
                return RedirecToNotFound(id);
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.AdminRole)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await iPxl.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
        private RedirectToActionResult RedirecToNotFound()
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { categorie = "Student" });
        }
        private RedirectToActionResult RedirecToNotFound(int? id = 0)
        {
            return RedirectToAction(NotFoundIdInfo.ActionName, NotFoundIdInfo.ControllerName, new { id, categorie = "Student" });
        }
    }
}
