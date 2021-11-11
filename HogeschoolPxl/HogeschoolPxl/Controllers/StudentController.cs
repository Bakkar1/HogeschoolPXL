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
            //return View(await _context.students.Include(s => s.Gebruiker).ToListAsync());
            return View(await iPxl.GetStudenten());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            //var student = await _context.students
            //    .FirstOrDefaultAsync(m => m.StudentId == id);
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,GebruikerId")] Student student)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(student);
                //await _context.SaveChangesAsync();
                await iPxl.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            //var student = await _context.students.FindAsync(id);
            var student = await iPxl.GetStudent(id);
            if (student == null)
            {
                return RedirecToNotFound(id);
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,GebruikerId")] Student student)
        {
            if (id != student.StudentId)
            {
                return RedirecToNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(student);
                    //await _context.SaveChangesAsync();
                    await iPxl.UpdateStudent(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iPxl.StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirecToNotFound();
            }

            //var student = await _context.students
            //    .FirstOrDefaultAsync(m => m.StudentId == id);
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var student = await _context.students.FindAsync(id);
            //_context.students.Remove(student);
            //await _context.SaveChangesAsync();
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
