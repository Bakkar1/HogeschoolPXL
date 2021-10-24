using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
