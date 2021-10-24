using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class VakLector
    {
        public int VakLectorId { get; set; }
        public int? LectorId { get; set; }
        public Lector Lector { get; set; }
        public int VakId { get; set; }
        public Vak Vak { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
