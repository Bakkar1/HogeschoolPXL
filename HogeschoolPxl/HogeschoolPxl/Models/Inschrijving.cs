using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Models
{
    public class Inschrijving
    {
        public int InschrijvingId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int VakLectorId { get; set; }
        public VakLector VakLector { get; set; }
        public int AcademieJaarId { get; set; }
        public AcademieJaar AcademieJaar { get; set; }
    }
}
