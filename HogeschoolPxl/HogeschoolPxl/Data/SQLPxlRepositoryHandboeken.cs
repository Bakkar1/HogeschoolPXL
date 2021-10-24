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
        public Handboek GetHandboek(int id)
        {
            return _context.handboeken.Find(id);
        }
        public async Task<Handboek> DetailsHandboek(int? id)
        {
            return await _context.handboeken
                .FirstOrDefaultAsync(m => m.HandboekId == id);
        }
        public async Task<Handboek> AddHandboek(Handboek handboek)
        {
            _context.handboeken.Add(handboek);
            await _context.SaveChangesAsync();
            return handboek;
        }
    }
}
