using HogeschoolPxl.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFoundEr(int? id, string categorie)
        {
            ErrorInfo errorInfo = new ErrorInfo()
            {
                id = id,
                categorie = categorie
            };
            return View("NotFound", errorInfo);
        }
    }
}
