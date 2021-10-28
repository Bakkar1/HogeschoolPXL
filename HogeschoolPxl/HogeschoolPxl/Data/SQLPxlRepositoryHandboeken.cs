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
        public async Task<IEnumerable<Handboek>> GetHandboeken()
        {
            return await _context.handboeken.ToListAsync();
        }
        public async Task<Handboek> GetHandboek(int? id)
        {
            return await _context.handboeken.FindAsync(id);
        }
        public async Task<Handboek> AddHandboek(Handboek handboek)
        {
            _context.handboeken.Add(handboek);
            await _context.SaveChangesAsync();
            return handboek;
        }
        public async Task<Handboek> UpdateHandboek(Handboek handboek)
        {
            _context.handboeken.Update(handboek);
            await _context.SaveChangesAsync();
            return handboek;
        }
        public async Task<Handboek> DeleteHandboek(int id)
        {
            var handboek = await _context.handboeken.FindAsync(id);
            _context.handboeken.Remove(handboek);
            await _context.SaveChangesAsync();
            return handboek;
        }
    }
}
