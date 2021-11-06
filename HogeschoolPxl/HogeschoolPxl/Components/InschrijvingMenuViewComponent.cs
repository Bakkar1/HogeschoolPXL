using HogeschoolPxl.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Components
{
    public class InschrijvingMenuViewComponent : ViewComponent
    {
        private readonly AppDbContext context;

        public InschrijvingMenuViewComponent(AppDbContext context)
        {
            this.context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(
            context.AcademieJaaren
            .Select(x => x.StartDatum.Year.ToString())
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
