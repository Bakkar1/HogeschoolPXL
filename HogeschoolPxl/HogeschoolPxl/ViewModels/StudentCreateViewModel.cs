using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class StudentCreateViewModel : Student
    {
        public IEnumerable<Gebruiker> Gebruikers { get; set; }
    }
}
