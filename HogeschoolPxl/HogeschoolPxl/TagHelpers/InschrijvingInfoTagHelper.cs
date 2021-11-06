using HogeschoolPxl.Data;
using HogeschoolPxl.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeschoolPxl.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "inschrijving")]
    public class InschrijvingInfoTagHelper : TagHelper
    {
        public Inschrijving inschrijving { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<div class='card m-1'>");
            html.Append("<div class='card-header bg-blue'>");
            html.Append($"{inschrijving.Student.Gebruiker.Naam}");
            html.Append("</div>");
            html.Append("<div class='card-body'>");
            html.Append($"<h5 class='card-title'>{inschrijving.VakLector.Vak.VakNaam}</h5>");
            html.Append("<p class='card-text'>");
            html.Append($"{inschrijving.Student.Gebruiker.VoorNaam} is ingeschreven voor academie jaar {inschrijving.AcademieJaar.StartDatum.Year}/{inschrijving.AcademieJaar.StartDatum.AddYears(1).Year}");
            html.Append("</p>");
            html.Append("<div class='links'>");
            html.Append($"<a href='Inschrijving/Edit/{inschrijving.InschrijvingId}' class='btn btn-primary m-1 text-white'>Edit</a>");
            html.Append($"<a href='Inschrijving/Details/{inschrijving.InschrijvingId}' class='btn btn-info m-1 text-white'>Details</a>");
            html.Append($"<a href='Inschrijving/Delete/{inschrijving.InschrijvingId}' class='btn btn-danger m-1 text-white'>Delete</a>");
            html.Append("</div>");
            html.Append("</div>");
            html.Append("</div>");
            output.Content.SetHtmlContent(html.ToString());
        }
    }
}
