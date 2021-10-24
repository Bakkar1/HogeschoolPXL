using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Gebruiker
    {
        public int GebruikerId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string VoorNaam { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Lector> lectoren { get; set; }
        public ICollection<Student> Studenten { get; set; }
    }
}
