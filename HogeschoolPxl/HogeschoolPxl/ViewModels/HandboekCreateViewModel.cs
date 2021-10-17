using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Http;

namespace HogeschoolPxl.ViewModels
{
    public class HandboekCreateViewModel : Handboek
    {
        public IFormFile Photo { get; set; }
    }
}
