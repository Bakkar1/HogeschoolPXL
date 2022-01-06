using HogeschoolPxl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data
{
    public class AppDbContext : IdentityDbContext<Gebruiker>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }
        public DbSet<Vak> Vakken{ get; set; }
        public DbSet<Handboek> Handboeken{ get; set; }
        public DbSet<Lector> Lectoren{ get; set; }
        public DbSet<VakLector> VakLectoren{ get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Inschrijving> Inschrijvingen{ get; set; }
        public DbSet<AcademieJaar> AcademieJaren{ get; set; }
    }
}
