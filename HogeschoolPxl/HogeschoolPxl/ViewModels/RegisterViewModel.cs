﻿using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.ViewModels
{
    public class RegisterViewModel : Gebruiker
    {
        public IFormFile Photo { get; set; }
        public string Password { get; set; }
    }
}
