using HogeschoolPxl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data
{
    public partial class PartialSQLPxlRepository
    {
        public async Task<IEnumerable<Student>> GetStudenten()
        {
            return await _context.Students.Include(s => s.Gebruiker).ToListAsync();
        }
        public async Task<IEnumerable<Student>> GetLectorStudenten(int lectorId)
        {
            return await _context.Students
                .Where(s => s.Inschrijvingen.Where(i => i.VakLector.LectorId == lectorId).Any())
                .Include(s => s.Gebruiker)
                .Select(s => s)
                .ToListAsync();
        }
        public async Task<Student> GetStudent(int? id)
        {
            return await _context.Students
                .Include(s => s.Gebruiker)
                .Where(s => s.StudentId == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Student>> GetStudentenByName(string nameOrFirstName)
        {
            var result = await _context.Students
                    .Where(s => s.Gebruiker.Naam.ToLower() == nameOrFirstName.ToLower() || s.Gebruiker.VoorNaam.ToLower() == nameOrFirstName.ToLower())
                    .Include(s => s.Gebruiker).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Inschrijving>> GetStudentOverzicht(int? id)
        {
            var result =  await _context.Inschrijvingen
                        .Include(v => v.VakLector.Lector)
                        .Include(v => v.VakLector.Vak)
                        .Include(v => v.VakLector.Vak.Handboek)
                        .Include(v => v.AcademieJaar)
                        .Where(i => i.Student.StudentId == id)
                        .OrderByDescending(i => i.AcademieJaar.StartDatum)
                        .ToListAsync();
            return result;
        }
        public async Task<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
        public async Task<bool> CheckStudent(string gebruikerId)
        {
            var result = await _context.Students.Where(l => l.Id == gebruikerId).FirstOrDefaultAsync();
            return result != null;
        }
    }
}
