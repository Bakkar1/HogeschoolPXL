#pragma checksum "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Lector\OwnCourses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f232e375501e272ab56c35b7493260183081ea96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lector_OwnCourses), @"mvc.1.0.view", @"/Views/Lector/OwnCourses.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f232e375501e272ab56c35b7493260183081ea96", @"/Views/Lector/OwnCourses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d1feab58c00ca484cb5a6c3c94972fc365d9775", @"/Views/_ViewImports.cshtml")]
    public class Views_Lector_OwnCourses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VakLector>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Handboek", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"d-flex p-2 flex-wrap\">\r\n");
#nullable restore
#line 4 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Lector\OwnCourses.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card m-1\">\r\n            <div class=\"card-header bg-blue\">\r\n                ");
#nullable restore
#line 8 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Lector\OwnCourses.cshtml"
           Write(item.Vak.VakNaam);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">Studiepunten : ");
#nullable restore
#line 11 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Lector\OwnCourses.cshtml"
                                                 Write(item.Vak.Studiepunten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">\r\n                    Boek : ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f232e375501e272ab56c35b7493260183081ea965876", async() => {
#nullable restore
#line 13 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Lector\OwnCourses.cshtml"
                                                                                                                     Write(item.Vak.Handboek.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Lector\OwnCourses.cshtml"
                                                                               WriteLiteral(item.Vak.Handboek.HandboekId);

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
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 17 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Lector\OwnCourses.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VakLector>> Html { get; private set; }
    }
}
#pragma warning restore 1591
