using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class StudentDetailsViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Inschrijving> Inschrijvingen { get; set; }
    }
}
