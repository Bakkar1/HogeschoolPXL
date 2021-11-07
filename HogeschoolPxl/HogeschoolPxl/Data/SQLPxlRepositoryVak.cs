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
        public async Task<IEnumerable<Vak>> GetVakken()
        {
            return await _context.Vakken.Include(v => v.Handboek).ToListAsync();
        }

        public async Task<Vak> GetVak(int? id)
        {
            return await _context.Vakken
                .FindAsync(id);
        }

        public async Task<Vak> AddVak(Vak vak)
        {
            _context.Vakken.Add(vak);
            await _context.SaveChangesAsync();
            return vak;
        }

        public async Task<Vak> UpdateVak(Vak vak)
        {
            _context.Vakken.Update(vak);
            await _context.SaveChangesAsync();
            return vak;
        }

        public async Task<Vak> DeleteVak(int id)
        {
            var vak = await _context.Vakken.FindAsync(id);
            _context.Vakken.Remove(vak);
            await _context.SaveChangesAsync();
            return vak;
        }

        public bool VakExists(int id)
        {
            return _context.Vakken.Any(e => e.VakId == id);
        }
    }
}
