using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Gebruiker : IdentityUser
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public string VoorNaam { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Lector> lectoren { get; set; }
        public ICollection<Student> Studenten { get; set; }
    }
}
