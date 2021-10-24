using HogeschoolPxl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class GebruikerEditViewModel : GebruikerCreateViewModel
    {
        public int HelperId { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
