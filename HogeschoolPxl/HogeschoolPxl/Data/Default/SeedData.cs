using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HogeschoolPxl.Data.Default
{
    public class SeedData
    {
        public const string EmailMbark = "mbark.bakkar@pxl.be";
        public const string EmailKrisotf = "Kristof.Palmaers@pxl.be";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider
                .GetRequiredService<AppDbContext>();


            UserManager<Gebruiker> userManager = app.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<UserManager<Gebruiker>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            
            
            await CreatIdentityRecord(context, userManager, roleManager);

            await FillTables(context, userManager, roleManager);

        }
        public static async Task CreatIdentityRecord(
           AppDbContext context,
           UserManager<Gebruiker> userManager,
           RoleManager<IdentityRole> roleManager)
        {

            if (!context.Roles.Any())
            {
                await CreateRole(roleManager, Roles.AdminRole);
                await CreateRole(roleManager, Roles.StudentRole);
                await CreateRole(roleManager, Roles.LectorRole);
            }

            var emailStudent = "student@pxl.be";
            var emailAdmin = "admin@pxl.be";

            if (await userManager.FindByEmailAsync(emailStudent) == null)
            {
                var pwd = "Student123!";
                var indetityUser = new Gebruiker()
                {
                    Email = emailStudent,
                    UserName = emailStudent,
                    VoorNaam = "default",
                    Naam = "Student"
                };
                var result = await userManager.CreateAsync(indetityUser, pwd);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(indetityUser, Roles.StudentRole);
                }
            }
            if (await userManager.FindByEmailAsync(emailAdmin) == null)
            {
                var pwd = "Admin456!";
                var indetityUser = new Gebruiker()
                {
                    Email = emailAdmin,
                    UserName = emailAdmin,
                    VoorNaam = "Admin",
                    Naam = "Admin"
                };
                var result = await userManager.CreateAsync(indetityUser, pwd);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(indetityUser, Roles.AdminRole);
                }
            }
            if (await userManager.FindByEmailAsync(EmailMbark) == null)
            {
                var pwd = "Mbark456!";
                var indetityUser = new Gebruiker()
                {
                    Email = EmailMbark,
                    UserName = EmailMbark,
                    Naam = "Bakkar",
                    VoorNaam = "Mbark"
                };
                var result = await userManager.CreateAsync(indetityUser, pwd);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(indetityUser, Roles.StudentRole);
                }
            }
            if (await userManager.FindByEmailAsync(EmailKrisotf) == null)
            {
                var pwd = "Kristof456!";
                var indetityUser = new Gebruiker()
                {
                    Email = EmailKrisotf,
                    UserName = EmailKrisotf,
                    Naam = "Palmaers",
                    VoorNaam = "Kristof"
                };
                var result = await userManager.CreateAsync(indetityUser, pwd);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(indetityUser, Roles.LectorRole);
                }
            }
        }
        private static async Task CreateRole(RoleManager<IdentityRole> roleManager,
            string role)
        {
            try
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    IdentityRole identityRole = new IdentityRole(role);
                    await roleManager.CreateAsync(identityRole);
                }
            }
            catch (Exception exp)
            {

                throw;
            }

        }

        public static async Task FillTables(AppDbContext context, UserManager<Gebruiker> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            var mbarkIdentity = await userManager.FindByEmailAsync(EmailMbark);
            var kristofIdentity = await userManager.FindByEmailAsync(EmailKrisotf);
            
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
                        Id = kristofIdentity.Id,
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
                        (l => l.Id == kristofIdentity.Id).FirstOrDefault().LectorId,
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
                        Id = mbarkIdentity.Id
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
                             (s => s.Id == mbarkIdentity.Id)
                             .FirstOrDefault().StudentId,
                    VakLectorId = context.VakLectoren.Where
                             (
                                 vk =>
                                 (vk.LectorId == context.Lectoren.Where(l => l.Id == kristofIdentity.Id).FirstOrDefault().LectorId
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
    public static class Roles
    {
        public const string AdminRole = "ADMIN";
        public const string StudentRole = "STUDENT";
        public const string LectorRole = "LECTOR";
    }
}
