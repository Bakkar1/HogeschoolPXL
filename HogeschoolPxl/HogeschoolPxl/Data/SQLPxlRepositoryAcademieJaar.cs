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
        public async Task<IEnumerable<AcademieJaar>> GetAcademieJaren()
        {
            return await _context.AcademieJaren.Include(a => a.Inschrijvingen).ToListAsync();
        }

        public async Task<AcademieJaar> GetAcademieJaar(int? id)
        {
            return await _context.AcademieJaren.FindAsync(id);
        }

        public async Task<AcademieJaar> AddAcademieJaar(AcademieJaar academieJaar)
        {
            _context.AcademieJaren.Add(academieJaar);
            await _context.SaveChangesAsync();
            return academieJaar;
        }

        public async Task<AcademieJaar> UpdateAcademieJaar(AcademieJaar academieJaar)
        {
            _context.AcademieJaren.Update(academieJaar);
            await _context.SaveChangesAsync();
            return academieJaar;
        }

        public async Task<AcademieJaar> DeleteAcademieJaar(int id)
        {
            var academieJaar = await _context.AcademieJaren.FindAsync(id);
            _context.AcademieJaren.Remove(academieJaar);
            await _context.SaveChangesAsync();
            return academieJaar;
        }

        public bool AcademieJaarExists(int id)
        {
            return _context.AcademieJaren.Any(e => e.AcademieJaarId == id);
        }
    }
}
