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
        public async Task<IEnumerable<Inschrijving>> GetInschrijvingen()
        {
            return await _context.Inschrijvingen
                .Include(i => i.Student.Gebruiker)
                .Include(i => i.VakLector.Vak)
                .Include(i => i.AcademieJaar)
                .ToListAsync();
        }
        public async Task<IEnumerable<Inschrijving>> GetInschrijvingenByYear(string year)
        {
            return await _context.Inschrijvingen
                .Include(i => i.Student.Gebruiker)
                .Include(i => i.VakLector.Vak)
                .Include(i => i.AcademieJaar)
                .Where(i => i.AcademieJaar.StartDatum.Year.ToString() == year).ToListAsync();
        }
        public async Task<Inschrijving> GetInschrijving(int? id)
        {
            return await _context.Inschrijvingen.FindAsync(id);
        }
        public async Task<Inschrijving> AddInschrijving(Inschrijving inschrijving)
        {
            _context.Inschrijvingen.Add(inschrijving);
            await _context.SaveChangesAsync();
            return inschrijving;
        }
        public async Task<Inschrijving> UpdateInschrijving(Inschrijving inschrijving)
        {
            _context.Inschrijvingen.Update(inschrijving);
            await _context.SaveChangesAsync();
            return inschrijving;
        }
        public async Task<Inschrijving> DeleteInschrijving(int id)
        {
            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            _context.Inschrijvingen.Remove(inschrijving);
            await _context.SaveChangesAsync();
            return inschrijving;
        }
    }
}
