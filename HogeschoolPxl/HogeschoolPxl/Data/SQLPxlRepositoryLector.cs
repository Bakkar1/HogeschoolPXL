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
            return await _context.Lectoren.ToListAsync();
        }

        public async Task<Lector> GetLector(int? id)
        {
            return await _context.Lectoren.FindAsync(id);
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
    }
}
