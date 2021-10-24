using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class GebruikerCreateViewModel : Gebruiker
    {
        public IFormFile Photo { get; set; }
    }
}
