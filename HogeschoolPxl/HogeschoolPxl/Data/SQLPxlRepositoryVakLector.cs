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
        public async Task<IEnumerable<VakLector>> GetVakLectoren()
        {
            return await _context.VakLectoren.ToListAsync();
        }

        public async Task<VakLector> GetVakLector(int? id)
        {
            return await _context.VakLectoren.FindAsync(id);
        }

        public async Task<VakLector> AddVakLector(VakLector vakLector)
        {
            _context.VakLectoren.Add(vakLector);
            await _context.SaveChangesAsync();
            return vakLector;
        }

        public async Task<VakLector> UpdateVakLector(VakLector vakLector)
        {
            _context.VakLectoren.Update(vakLector);
            await _context.SaveChangesAsync();
            return vakLector;
        }

        public async Task<VakLector> DeleteVakLector(int id)
        {
            var vakLector = await _context.VakLectoren.FindAsync(id);
            _context.VakLectoren.Remove(vakLector);
            await _context.SaveChangesAsync();
            return vakLector;
        }
    }
}
