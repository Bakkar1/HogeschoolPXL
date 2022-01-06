using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data
{
    public class MockPxlReository
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

        public void SeedData()
        {
            /*
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
                    VakId = 1
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
            */
        }

        public async Task<IEnumerable<Gebruiker>> GetGebruikers()
        {
            return await Task.Run(() => Gebruikers);
        }

        public Task<Gebruiker> GetGebruiker(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Gebruiker> AddGebruiker(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public Task<Gebruiker> UpdateGebruiker(Gebruiker gebruiker)
        {
            throw new NotImplementedException();
        }

        public Task<Gebruiker> DeleteGebruiker(int id)
        {
            throw new NotImplementedException();
        }

        public bool GebruikerExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Handboek>> GetHandboeken()
        {
            throw new NotImplementedException();
        }

        public Task<Handboek> GetHandboek(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Handboek> AddHandboek(Handboek handboek)
        {
            throw new NotImplementedException();
        }

        public Task<Handboek> UpdateHandboek(Handboek handboek)
        {
            throw new NotImplementedException();
        }

        public Task<Handboek> DeleteHandboek(int id)
        {
            throw new NotImplementedException();
        }

        public bool HandboekExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inschrijving>> GetInschrijvingen()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inschrijving>> GetInschrijvingenByYear(string year)
        {
            throw new NotImplementedException();
        }

        public Task<Inschrijving> GetInschrijving(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Inschrijving> AddInschrijving(Inschrijving inschrijving)
        {
            throw new NotImplementedException();
        }

        public Task<Inschrijving> UpdateInschrijving(Inschrijving inschrijving)
        {
            throw new NotImplementedException();
        }

        public Task<Inschrijving> DeleteInschrijving(int id)
        {
            throw new NotImplementedException();
        }

        public bool InschrijvingExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lector>> GetLectoren()
        {
            throw new NotImplementedException();
        }

        public Task<Lector> GetLector(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lector>> GetLectorenByName(string nameOrFirstName)
        {
            throw new NotImplementedException();
        }

        public Task<Lector> AddLector(Lector lector)
        {
            throw new NotImplementedException();
        }

        public Task<Lector> UpdateLector(Lector Lector)
        {
            throw new NotImplementedException();
        }

        public Task<Lector> DeleteLector(int id)
        {
            throw new NotImplementedException();
        }

        public bool LectorExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Lector> CheckLector(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetStudenten()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudent(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inschrijving>> GetStudentOverzicht(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetStudentenByName(string nameOrFirstName)
        {
            throw new NotImplementedException();
        }

        public Task<Student> AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Student> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public bool StudentExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckStudent(int gebruikerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vak>> GetVakken()
        {
            throw new NotImplementedException();
        }

        public Task<Vak> GetVak(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Vak> AddVak(Vak vak)
        {
            throw new NotImplementedException();
        }

        public Task<Vak> UpdateVak(Vak vak)
        {
            throw new NotImplementedException();
        }

        public Task<Vak> DeleteVak(int id)
        {
            throw new NotImplementedException();
        }

        public bool VakExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VakLector>> GetVakLectoren()
        {
            throw new NotImplementedException();
        }

        public Task<VakLector> GetVakLector(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<VakLector> GetVakLectorByLector(int vakLecotrId)
        {
            throw new NotImplementedException();
        }

        public Task<VakLector> AddVakLector(VakLector vakLector)
        {
            throw new NotImplementedException();
        }

        public Task<VakLector> UpdateVakLector(VakLector vakLector)
        {
            throw new NotImplementedException();
        }

        public Task<VakLector> DeleteVakLector(int id)
        {
            throw new NotImplementedException();
        }

        public bool VakLectorExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AcademieJaar>> GetAcademieJaren()
        {
            throw new NotImplementedException();
        }

        public Task<AcademieJaar> GetAcademieJaar(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<AcademieJaar> AddAcademieJaar(AcademieJaar academieJaar)
        {
            throw new NotImplementedException();
        }

        public Task<AcademieJaar> UpdateAcademieJaar(AcademieJaar academieJaar)
        {
            throw new NotImplementedException();
        }

        public Task<AcademieJaar> DeleteAcademieJaar(int id)
        {
            throw new NotImplementedException();
        }

        public bool AcademieJaarExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VakLector>> GetEigenVakken(int lectorId)
        {
            throw new NotImplementedException();
        }

        public SelectList GetRoles()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCurrentUserAlector()
        {
            throw new NotImplementedException();
        }
    }
}
