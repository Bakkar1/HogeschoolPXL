using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HogeschoolPxl.Data
{
    public interface IPxl
    {
        SelectList GetRoles();
        void DeleteOldRoles(string UserId);
        string GetRoleName(string UserId);
        Task<string> CurrentUserRoleName();
        #region Gebruiker
        Task<IEnumerable<Gebruiker>> GetGebruikers();
        Task<Gebruiker> GetGebruiker(string id);
        Task<Gebruiker> GetGebruikerByName(string userName);
        Task<Gebruiker> AddGebruiker(Gebruiker gebruiker);
        Task<Gebruiker> UpdateGebruiker(Gebruiker gebruiker);
        Task<Gebruiker> DeleteGebruiker(string id);

        bool GebruikerExists(string id);
        #endregion

        #region handboek
        Task<IEnumerable<Handboek>> GetHandboeken();
        Task<Handboek> GetHandboek(int? id);
        Task<Handboek> AddHandboek(Handboek handboek);
        Task<Handboek> UpdateHandboek(Handboek handboek);
        Task<Handboek> DeleteHandboek(int id);

        bool HandboekExists(int id);
        #endregion

        #region Inchrijving
        Task<IEnumerable<Inschrijving>> GetInschrijvingen();
        Task<IEnumerable<Inschrijving>> GetInschrijvingenByYear(string year);
        Task<Inschrijving> GetInschrijving(int? id);
        Task<Inschrijving> AddInschrijving(Inschrijving inschrijving);
        Task<Inschrijving> UpdateInschrijving(Inschrijving inschrijving);
        Task<Inschrijving> DeleteInschrijving(int id);

        bool InschrijvingExists(int id);
        #endregion

        #region Lector
        Task<IEnumerable<Lector>> GetLectoren();
        Task<Lector> GetLector(int? id);
        Task<IEnumerable<Lector>> GetLectorenByName(string nameOrFirstName);
        Task<Lector> AddLector(Lector lector);
        Task<Lector> UpdateLector(Lector Lector);
        Task<Lector> DeleteLector(int id);
        bool LectorExists(int id);
        Task<Lector> CheckLector(string id);
        Task<IEnumerable<VakLector>> GetEigenVakken(int lectorId);
        #endregion

        #region Student
        Task<IEnumerable<Student>> GetStudenten();
        Task<Student> GetStudent(int? id);
        Task<IEnumerable<Inschrijving>> GetStudentOverzicht(int? id);

        Task<IEnumerable<Student>> GetStudentenByName(string nameOrFirstName);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int id);

        bool StudentExists(int id);
        Task<bool> CheckStudent(string gebruikerId);
        #endregion

        #region Vak
        Task<IEnumerable<Vak>> GetVakken();
        Task<Vak> GetVak(int? id);
        Task<Vak> AddVak(Vak vak);
        Task<Vak> UpdateVak(Vak vak);
        Task<Vak> DeleteVak(int id);

        bool VakExists(int id);
        #endregion

        #region VakLector
        Task<IEnumerable<VakLector>> GetVakLectoren();
        Task<IEnumerable<Vak>> GetLectorVakken(int lectorId);
        Task<IEnumerable<Student>> GetLectorStudenten(int lectorId);
        Task<IEnumerable<Handboek>> GetLectorHandboeken(int lectorId);
        Task<VakLector> GetVakLector(int? id);
        Task<VakLector> GetVakLectorByLector(int vakLecotrId);
        Task<VakLector> AddVakLector(VakLector vakLector);
        Task<VakLector> UpdateVakLector(VakLector vakLector);
        Task<VakLector> DeleteVakLector(int id);

        bool VakLectorExists(int id);
        #endregion

        #region AcademieJaar
        Task<IEnumerable<AcademieJaar>> GetAcademieJaren();
        Task<AcademieJaar> GetAcademieJaar(int? id);
        Task<AcademieJaar> AddAcademieJaar(AcademieJaar academieJaar);
        Task<AcademieJaar> UpdateAcademieJaar(AcademieJaar academieJaar);
        Task<AcademieJaar> DeleteAcademieJaar(int id);
        bool AcademieJaarExists(int id);
        #endregion
    }
}
