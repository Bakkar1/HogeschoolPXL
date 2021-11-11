using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class VakLectorEditViewModel : VakLector
    {
        public IEnumerable<Lector> Lectoren { get; set; }
        public IEnumerable<Vak> Vakken { get; set; }
    }
}
