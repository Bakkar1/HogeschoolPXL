using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Inschrijving
    {
        public int InchrijvingId { get; set; }
        public int StudentId { get; set; }
        public int VakLectorId { get; set; }
        public int AcademieJaarId { get; set; }
    }
}
