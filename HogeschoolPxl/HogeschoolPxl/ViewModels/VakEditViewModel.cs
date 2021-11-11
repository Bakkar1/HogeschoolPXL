using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class VakEditViewModel : Vak
    {
        public IEnumerable<Handboek> Handboeken { get; set; }
    }
}
