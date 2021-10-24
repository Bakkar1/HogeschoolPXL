using HogeschoolPxl.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Vak
    {
        public int VakId { get; set; }
        [Required]
        public string VakNaam { get; set; }
        [Required]
        public int Studiepunten { get; set; }
        public int HandboekId { get; set; }
        public Handboek Handboek { get; set; }
        public ICollection<VakLector> VakLectoren { get; set; }
    }
}
