using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class GebruikerEditViewModel : Gebruiker
    {
        public IFormFile Photo { get; set; }
        public string RoleId { get; set; }
        public string HelperId { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
