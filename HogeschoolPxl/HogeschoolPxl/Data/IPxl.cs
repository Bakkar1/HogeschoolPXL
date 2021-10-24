using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogeschoolPxl.Models;

namespace HogeschoolPxl.Data
{
    public interface IPxl
    {
        //Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Gebruiker>> GetGebruikersAsync();
        IEnumerable<Gebruiker> GetGebruikers();


        Task<IEnumerable<Handboek>> GetHandboeken();
        Handboek GetHandboek(int id);
        Task<Handboek> DetailsHandboek(int? id);
        Task<Handboek> AddHandboek(Handboek handboek);
    }
}
