using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [ForeignKey("Gebruiker")]
        public string Id { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
