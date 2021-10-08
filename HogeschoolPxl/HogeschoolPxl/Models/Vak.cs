using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Vak
    {
        public int VakId { get; set; }
        public string VakNaam { get; set; }
        public int Studiepunten { get; set; }
        public int HandboekId { get; set; }
    }
}
