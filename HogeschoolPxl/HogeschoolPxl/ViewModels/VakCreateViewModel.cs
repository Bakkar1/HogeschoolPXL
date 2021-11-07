using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class VakCreateViewModel : Vak
    {
        public IEnumerable<Handboek> Handboeken { get; set; }
    }
}
