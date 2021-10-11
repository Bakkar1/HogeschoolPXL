using HogeschoolPxl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Vak> Vakken{ get; set; }
        public DbSet<Handboek> handboeken{ get; set; }
        public DbSet<Lector> Lectoren{ get; set; }
        public DbSet<VakLector> VakLectoren{ get; set; }
        public DbSet<Student> students{ get; set; }
        public DbSet<Inschrijving> Inschrijvingen{ get; set; }
        public DbSet<AcademieJaar> AcademieJaaren{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().HasData(
                new Gebruiker()
                {
                    GebruikerId = 1,
                    Naam = "Bakkar",
                    VoorNaam = "Mbark",
                    Email = "mbark.bakkar@pxl.be"
                },
                new Gebruiker()
                {
                    GebruikerId = 2,
                    Naam = "Palmaers",
                    VoorNaam = "Kristof",
                    Email = "Kristof.Palmaers@pxl.be"
                }
            );
            modelBuilder.Entity<Vak>().HasData(
                new Vak()
                {
                    VakId = 1,
                    VakNaam = "C# Web",
                    Studiepunten = 5,
                    HandboekId = 1
                });
            modelBuilder.Entity<Lector>().HasData(
                new Lector()
                {
                    LectorId = 1,
                    GebruikerId = 2
                });

            modelBuilder.Entity<VakLector>().HasData(
                new VakLector()
                {
                    VakLectorId = 1,
                    LectorId = 1,
                    GebruikerId = 1
                });
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    StudentId = 1,
                    GebruikerId = 1
                });
            modelBuilder.Entity<Handboek>().HasData(
                new Handboek()
                {
                    HandboekId = 1,
                    Title = "C# Web 1",
                    KostPrijs = 30
                });
            modelBuilder.Entity<Inschrijving>().HasData(
                new Inschrijving()
                {
                    InschrijvingId = 1,
                    StudentId = 1,
                    VakLectorId = 1,
                    AcademieJaarId = 1
                });
            modelBuilder.Entity<AcademieJaar>().HasData(
                new AcademieJaar()
                {
                    AcademieJaarId = 1,
                    StartDatum = DateTime.Now
                });
        }

    }
}
