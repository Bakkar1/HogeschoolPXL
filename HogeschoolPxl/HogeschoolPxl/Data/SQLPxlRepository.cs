using HogeschoolPxl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data
{
    public class SQLPxlRepository
    {
        private readonly AppDbContext _context;
        public SQLPxlRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gebruiker>> GetGebruikersAsync()
        {
            return await _context.Gebruikers.ToListAsync();
        }
        public IEnumerable<Gebruiker> GetGebruikers()
        {
            return _context.Gebruikers;
        }
        //public async Task<IEnumerable<Student>> GetStudenten()
        //{
        //    return await _context..ToListAsync();
        //}

        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

        public Handboek GetHandboek(int id)
        {
            return _context.Handboeken.Find(id);
        }
    }
}
