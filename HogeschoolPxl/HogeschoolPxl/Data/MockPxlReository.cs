using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data
{
    public class MockPxlReository : IPxl
    {
        public List<Gebruiker> Gebruikers;
        public List<Vak> Vakken;
        public List<Handboek> handboeken;
        public List<Lector> Lectoren;
        public List<VakLector> VakLectoren;
        public List<Student> Studenten;
        public List<Inschrijving> Inschrijvingen;
        public List<AcademieJaar> AcademieJaaren;
        public MockPxlReository()
        {
            SeedData();
        }

        public async Task<IEnumerable<Gebruiker>> GetGebruikersAsync()
        {
            return await Task.Run(() => Gebruikers);
        }

        public IEnumerable<Gebruiker> GetGebruikers()
        {
            return Gebruikers;
        }
        public void SeedData()
        {
            Gebruikers = new List<Gebruiker>()
            {
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
            };
            Vakken = new List<Vak>()
            {
                new Vak()
                {
                    VakId = 1,
                    VakNaam = "C# Web",
                    Studiepunten = 5,
                    HandboekId = 1
                }
            };
            Lectoren = new List<Lector>()
            {
                new Lector()
                {
                    LectorId = 1,
                    GebruikerId = 2
                }
            };
            VakLectoren = new List<VakLector>()
            {
                new VakLector()
                {
                    VakLectorId = 1,
                    LectorId = 1,
                    GebruikerId = 1
                }
            };
            Studenten = new List<Student>()
            {
                new Student()
                {
                    StudentId= 1,
                    GebruikerId = 1
                }
            };
            handboeken = new List<Handboek>()
            {
                new Handboek()
                {
                    HandboekId = 1,
                    Title = "C# Web 1",
                    KostPrijs = 30
                }
            };
            Inschrijvingen = new List<Inschrijving>()
            {
                new Inschrijving()
                {
                    InschrijvingId = 1,
                    StudentId = 1,
                    VakLectorId = 1,
                    AcademieJaarId = 1
                }
            };
            AcademieJaaren = new List<AcademieJaar>()
            {
                new AcademieJaar()
                {
                    AcademieJaarId = 1,
                    StartDatum  = DateTime.Now
                }
            };
        }
    }
}
