using HogeschoolPxl.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Handboek
    {
        public int HandboekId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double KostPrijs { get; set; }
        [Required]
        [UitgifteDatum]
        public DateTime UitGifteDatum { get; set; }
        public string Afbeelding { get; set; }
        public ICollection<Vak> Vakken { get; set; }
    }
}
