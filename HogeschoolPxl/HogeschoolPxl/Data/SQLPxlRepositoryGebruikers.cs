using HogeschoolPxl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data
{
    public partial class PartialSQLPxlRepository : IPxl
    {
        private readonly AppDbContext _context;
        public PartialSQLPxlRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Gebruiker>> GetGebruikers()
        {
            return await _context.Gebruikers.ToListAsync();
        }
        public async Task<Gebruiker> GetGebruiker(int? id)
        {
            return await _context.Gebruikers.FindAsync(id);
        }
        public async Task<Gebruiker> AddGebruiker(Gebruiker gebruiker)
        {
            _context.Gebruikers.Add(gebruiker);
            await _context.SaveChangesAsync();
            return gebruiker;
        }
        public async Task<Gebruiker> UpdateGebruiker(Gebruiker gebruiker)
        {
            _context.Gebruikers.Update(gebruiker);
            await _context.SaveChangesAsync();
            return gebruiker;
        }
        public async Task<Gebruiker> DeleteGebruiker(int id)
        {
            var gebruiker = await _context.Gebruikers.FindAsync(id);
            _context.Gebruikers.Remove(gebruiker);
            await _context.SaveChangesAsync();
            return gebruiker;
        }

        public bool GebruikerExists(int id)
        {
            return _context.Gebruikers.Any(e => e.GebruikerId == id);
        }
    }
}
