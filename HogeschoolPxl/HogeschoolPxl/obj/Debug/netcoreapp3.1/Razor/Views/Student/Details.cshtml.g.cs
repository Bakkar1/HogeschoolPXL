#pragma checksum "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d85320bf625da164e9b4c1d78fa3e588d4458058"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Details), @"mvc.1.0.view", @"/Views/Student/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\_ViewImports.cshtml"
using HogeschoolPxl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\_ViewImports.cshtml"
using HogeschoolPxl.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\_ViewImports.cshtml"
using HogeschoolPxl.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\_ViewImports.cshtml"
using HogeschoolPxl.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\_ViewImports.cshtml"
using HogeschoolPxl.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d85320bf625da164e9b4c1d78fa3e588d4458058", @"/Views/Student/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d1feab58c00ca484cb5a6c3c94972fc365d9775", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
  
    ViewData["Title"] = "Details";
    var photoPath = "/images/" + (Model.Student.Gebruiker.ImageUrl ?? "nogebruiker.png");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 class=\"cat-heading\">Details ");
#nullable restore
#line 8 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
                           Write(Model.Student.Gebruiker.Naam);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<div class=\"overzicht-card\">\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 276, "\"", 292, 1);
#nullable restore
#line 10 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
WriteAttributeValue("", 282, photoPath, 282, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"profile foto\">\r\n    <h3>\r\n        ");
#nullable restore
#line 12 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
   Write(Model.Student.Gebruiker.Naam);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 12 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
                                 Write(Model.Student.Gebruiker.VoorNaam);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </h3>\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 415, "\"", 452, 1);
#nullable restore
#line 14 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
WriteAttributeValue("", 422, Model.Student.Gebruiker.Email, 422, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 14 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
                                         Write(Model.Student.Gebruiker.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    <div class=\"links\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d85320bf625da164e9b4c1d78fa3e588d44580587916", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
                                                               WriteLiteral(Model.Student.StudentId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d85320bf625da164e9b4c1d78fa3e588d445805810226", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div>\r\n");
#nullable restore
#line 21 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
     if (Model.Inschrijvingen.Any())
    {
        foreach (var inschrijving in Model.Inschrijvingen)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card m-1\">\r\n                <div class=\"card-header bg-blue\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
               Write(inschrijving.VakLector.Vak.VakNaam);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">Academiejaar ");
#nullable restore
#line 30 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
                                                   Write(inschrijving.AcademieJaar.StartDatum.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 30 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
                                                                                              Write(inschrijving.AcademieJaar.StartDatum.AddYears(1).Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\">\r\n                        ");
#nullable restore
#line 32 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
                   Write(inschrijving.VakLector.Vak.Studiepunten);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Studie Punten\r\n                    </p>\r\n                    <div>\r\n                        Handboek ");
#nullable restore
#line 35 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
                            Write(inschrijving.VakLector.Vak.Handboek.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 39 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Student\Details.cshtml"
        };
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
