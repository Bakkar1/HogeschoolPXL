using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class InschrijvingCreateViewModel : Inschrijving
    {
        public IEnumerable<Student> Studenten { get; set; }
        public IEnumerable<VakLector> VakLectoren { get; set; }
        public IEnumerable<AcademieJaar>  AcademieJaren{ get; set; }
    }
}
