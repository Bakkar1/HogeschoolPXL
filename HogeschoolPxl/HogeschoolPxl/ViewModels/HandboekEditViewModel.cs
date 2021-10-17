using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogeschoolPxl.ViewModels;

namespace HogeschoolPxl.ViewModels
{
    public class HandboekEditViewModel : HandboekCreateViewModel
    {
        public int HelperId { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
