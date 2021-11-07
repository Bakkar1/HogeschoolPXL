using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data.Default
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider
                .GetRequiredService<AppDbContext>();

            if (!context.Gebruikers.Any())
            {
                context.Gebruikers.AddRange(
                    new Gebruiker()
                    {
                        Naam = "Bakkar",
                        VoorNaam = "Mbark",
                        Email = "mbark.bakkar@pxl.be"
                    },
                    new Gebruiker()
                    {
                        Naam = "Palmaers",
                        VoorNaam = "Kristof",
                        Email = "Kristof.Palmaers@pxl.be"
                    }
                );
                context.SaveChanges();
            }
            if (!context.Handboeken.Any())
            {
                context.Handboeken.AddRange(
                    new Handboek()
                    {
                        Title = "C# Web 1",
                        KostPrijs = 30
                    }
                );
                context.SaveChanges();
            }
            if (!context.Lectoren.Any())
            {
                context.Lectoren.AddRange(
                    new Lector()
                    {
                        GebruikerId = context.Gebruikers.Where(g => g.Naam == "Palmaers").FirstOrDefault().GebruikerId,
                    }
                );
                context.SaveChanges();
            }
            if (!context.Vakken.Any())
            {
                context.Vakken.AddRange(
                     new Vak()
                     {
                         VakNaam = "C# Web 1",
                         Studiepunten = 5,
                         HandboekId = context.Handboeken.Where(h => h.Title == "C# Web 1").FirstOrDefault().HandboekId
                     }
                );
                context.SaveChanges();
            }
            if (!context.VakLectoren.Any())
            {
                context.VakLectoren.AddRange(
                    new VakLector()
                    {
                        LectorId = context.Lectoren.Where
                        (l =>  l.GebruikerId == context.Gebruikers.Where(g => g.Naam == "Palmaers").FirstOrDefault().GebruikerId)
                        .FirstOrDefault().LectorId,
                        VakId = context.Vakken.Where(v => v.VakNaam == "C# Web 1").FirstOrDefault().VakId
                    }
                );
                context.SaveChanges();
            }
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student()
                    {
                        GebruikerId = context.Gebruikers.Where(g => g.Naam == "Bakkar").FirstOrDefault().GebruikerId
                    }
                );
                context.SaveChanges();
            }
            if (!context.AcademieJaren.Any())
            {
                context.AcademieJaren.AddRange(
                    new AcademieJaar()
                    {
                        StartDatum = DateTime.Parse("09/20/2021")
                    }
                );
                context.SaveChanges();
            }
            if (!context.Inschrijvingen.Any())
            {
                context.Inschrijvingen.AddRange(
                new Inschrijving()
                {
                    StudentId = context.Students.Where
                             (s => s.GebruikerId == context.Gebruikers.Where(g => g.Naam == "Bakkar").FirstOrDefault().GebruikerId)
                             .FirstOrDefault().StudentId,
                    VakLectorId = context.VakLectoren.Where
                             (
                                 vk =>
                                 (vk.LectorId == context.Lectoren.Where(l => l.GebruikerId == context.Gebruikers.Where(g => g.Naam == "Palmaers").FirstOrDefault().GebruikerId).FirstOrDefault().LectorId
                                 &&
                                 vk.VakId == context.Vakken.Where(v => v.VakNaam == "C# Web 1").FirstOrDefault().VakId)

                            ).FirstOrDefault().VakLectorId
                         ,
                    AcademieJaarId = 1
                });
                context.SaveChanges();
            }

        }
    }
}
