#pragma checksum "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81dafb59b8bcec7758eb9ec18f9cca134011578e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Error_NotFound), @"mvc.1.0.view", @"/Views/Error/NotFound.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81dafb59b8bcec7758eb9ec18f9cca134011578e", @"/Views/Error/NotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a39017c04bcb9e08eea6e900f77ec38aeba8b2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Error_NotFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorInfo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/NotFoundStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml"
  
    ViewBag.Title = "Not found";

#line default
#line hidden
#nullable disable
            DefineSection("NotFoundStyle", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "81dafb59b8bcec7758eb9ec18f9cca134011578e4933", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-md-12\">\r\n            <h1><i class=\"fa fa-exclamation-triangle\" aria-hidden=\"true\"></i> 404</h1>\r\n");
#nullable restore
#line 14 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml"
             if (Model.Id == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2>Oops... We kan not find ");
#nullable restore
#line 16 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml"
                                       Write(Model.Categorie);

#line default
#line hidden
#nullable disable
            WriteLiteral(" without ");
#nullable restore
#line 16 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml"
                                                                Write(Model.Categorie);

#line default
#line hidden
#nullable disable
            WriteLiteral("  number</h2>\r\n");
#nullable restore
#line 17 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2>Oops... We could not found ");
#nullable restore
#line 20 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml"
                                          Write(Model.Categorie);

#line default
#line hidden
#nullable disable
            WriteLiteral(" with id : ");
#nullable restore
#line 20 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml"
                                                                     Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n");
#nullable restore
#line 21 "C:\Users\mbark\OneDrive\Documents\GitHub\HogeschoolPXL\HogeschoolPxl\HogeschoolPxl\Views\Error\NotFound.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81dafb59b8bcec7758eb9ec18f9cca134011578e8492", async() => {
                WriteLiteral("\r\n                <input type=\"text\" placeholder=\"Search...\" name=\"search\">\r\n                <button type=\"submit\"><i class=\"fa fa-search\" aria-hidden=\"true\"></i></button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

            <p>If you think you have arrived here by our mistake, please <a href=""#"">contact us</a></p>

            <h3>Follow us:</h3>
            <div class=""social-networks"">
                <a href=""https://www.facebook.com/"" target=""_blank""><i class=""fab fa-facebook-square""></i></a>
                <a href=""https://www.pinterest.com/"" target=""_blank""><i class=""fab fa-pinterest-square""></i></a>
                <a href=""https://twitter.com/"" target=""_blank""><i class=""fab fa-twitter-square""></i></a>
            </div>
        </div>
    </div>
</div>

<footer>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                &copy; 2016 All Rights Reserved <a href=""#"" target=""_blank"">www.HogeschoolPxl.com</a>
            </div>
        </div>
    </div>
</footer>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591
