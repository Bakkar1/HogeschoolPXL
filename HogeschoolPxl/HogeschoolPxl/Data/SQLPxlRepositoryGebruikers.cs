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
        public IEnumerable<Gebruiker> GetGebruikers()
        {
            return _context.Gebruikers;
        }
        public async Task<IEnumerable<Gebruiker>> GetGebruikersAsync()
        {
            return await _context.Gebruikers.ToListAsync();
        }
        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
