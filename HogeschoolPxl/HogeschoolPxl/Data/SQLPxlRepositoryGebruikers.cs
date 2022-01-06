using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Gebruiker> userManager;
        public PartialSQLPxlRepository(AppDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<Gebruiker> userManager)
        {
            _context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<Gebruiker>> GetGebruikers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Gebruiker> GetGebruiker(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<Gebruiker> GetGebruikerByName(string userName)
        {
            return await _context.Users
                            .Where(u => u.UserName == userName)
                            .Include(u => u.lectoren).ThenInclude(l => l)
                            .Include(u => u.Studenten).ThenInclude(s => s)
                            .FirstOrDefaultAsync();
        }
        public async Task<Gebruiker> AddGebruiker(Gebruiker gebruiker)
        {
            _context.Users.Add(gebruiker);
            await _context.SaveChangesAsync();
            return gebruiker;
        }
        public async Task<Gebruiker> UpdateGebruiker(Gebruiker gebruiker)
        {
            _context.Users.Update(gebruiker);
            await _context.SaveChangesAsync();
            return gebruiker;
        }
        public async Task<Gebruiker> DeleteGebruiker(string id)
        {
            var gebruiker = await _context.Users.FindAsync(id);
            DeleteOldRoles(gebruiker.Id);
            _context.Users.Remove(gebruiker);
            await _context.SaveChangesAsync();
            return gebruiker;
        }

        public bool GebruikerExists(string id)
        {
            return _context.Users.Any(e => e.Id == id.ToString());
        }


    }
}
