using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class LectorCreateViewModel : Lector
    {
        public IEnumerable<Gebruiker> Gebruikers { get; set; }
    }
}
