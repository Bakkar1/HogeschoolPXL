using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogeschoolPxl.Models;

namespace HogeschoolPxl.Data
{
    public interface IPxl
    {
        #region Gebruiker
        Task<IEnumerable<Gebruiker>> GetGebruikers();
        Task<Gebruiker> GetGebruiker(int? id);
        Task<Gebruiker> AddGebruiker(Gebruiker gebruiker);
        Task<Gebruiker> UpdateGebruiker(Gebruiker gebruiker);
        Task<Gebruiker> DeleteGebruiker(int id);
        #endregion

        #region handboek
        Task<IEnumerable<Handboek>> GetHandboeken();
        Task<Handboek> GetHandboek(int? id);
        Task<Handboek> AddHandboek(Handboek handboek);
        Task<Handboek> UpdateHandboek(Handboek handboek);
        Task<Handboek> DeleteHandboek(int id);
        #endregion
        #region Inchrijving
        Task<IEnumerable<Inschrijving>> GetInschrijvingen();
        Task<Inschrijving> GetInschrijving(int? id);
        Task<Inschrijving> AddInschrijving(Inschrijving inschrijving);
        Task<Inschrijving> UpdateInschrijving(Inschrijving inschrijving);
        Task<Inschrijving> DeleteInschrijving(int id);
        #endregion
    }
}
