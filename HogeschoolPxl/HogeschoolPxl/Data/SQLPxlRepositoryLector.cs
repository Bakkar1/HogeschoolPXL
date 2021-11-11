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
        public async Task<IEnumerable<Lector>> GetLectoren()
        {
            return await _context.Lectoren.Include(l => l.Gebruiker).ToListAsync();
        }

        public async Task<Lector> GetLector(int? id)
        {
            return await _context.Lectoren
               .Include(s => s.Gebruiker)
               .Where(s => s.LectorId == id)
               .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Lector>> GetLectorenByName(string searchName)
        {
            var result = await _context.Lectoren
                    .Where(s => s.Gebruiker.Naam.ToLower() == searchName.ToLower() || s.Gebruiker.VoorNaam.ToLower() == searchName.ToLower())
                    .Include(s => s.Gebruiker).ToListAsync();
            return result;
        }
        public async Task<Lector> AddLector(Lector lector)
        {
            _context.Lectoren.Add(lector);
            await _context.SaveChangesAsync();
            return lector;
        }

        public async Task<Lector> UpdateLector(Lector Lector)
        {
            _context.Lectoren.Update(Lector);
            await _context.SaveChangesAsync();
            return Lector;
        }

        public async Task<Lector> DeleteLector(int id)
        {
            var lector = await _context.Lectoren.FindAsync(id);
            _context.Lectoren.Remove(lector);
            await _context.SaveChangesAsync();
            return lector;
        }
        public bool LectorExists(int id)
        {
            return _context.Lectoren.Any(e => e.LectorId == id);
        }
        public async Task<Lector> CheckLector(int gebruikerId)
        {
            return await _context.Lectoren.Where(l => l.GebruikerId == gebruikerId).FirstOrDefaultAsync();
        }
    }
}
