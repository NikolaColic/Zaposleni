#pragma checksum "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97bae9f850b41d33feffb99299b50faf669fc902"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Radnik_Vrati), @"mvc.1.0.view", @"/Views/Radnik/Vrati.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Radnik/Vrati.cshtml", typeof(AspNetCore.Views_Radnik_Vrati))]
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
#line 1 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\_ViewImports.cshtml"
using ZaposleniMVC;

#line default
#line hidden
#line 2 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\_ViewImports.cshtml"
using ZaposleniMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97bae9f850b41d33feffb99299b50faf669fc902", @"/Views/Radnik/Vrati.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"616840981d19ed95940b5dd35b7deb5bf884e886", @"/Views/_ViewImports.cshtml")]
    public class Views_Radnik_Vrati : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ZaposleniMVC.Models.Odgovor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Prijava", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Radnik", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(36, 169, true);
            WriteLiteral("<table class=\"table\">\r\n    <tr>\r\n\r\n        <th>Datum</th>\r\n        <th>Smena</th>\r\n        <th>Radno vreme</th>\r\n        <th>Obavestenja</th>\r\n        <th>Prijava</th>\r\n");
            EndContext();
#line 10 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
         foreach (var i in Model.Rasporedi)
        {

#line default
#line hidden
            BeginContext(261, 61, true);
            WriteLiteral("        <tr id=\"provera\">\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(323, 43, false);
#line 14 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
           Write(Html.Encode(i.Datum.ToString("dd-MM-yyyy")));

#line default
#line hidden
            EndContext();
            BeginContext(366, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(422, 29, false);
#line 17 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
           Write(Html.DisplayFor(m => i.Smena));

#line default
#line hidden
            EndContext();
            BeginContext(451, 41, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n");
            EndContext();
#line 21 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                  
                    var par = "";
                    if (i.Smena == "Prva")
                    {
                        par = "8-15h";
                    }
                    else if (i.Smena == "Druga")
                    {
                        par = "15-22h";
                    }
                    else
                    {
                        par = "Slobodan dan";
                    }
                

#line default
#line hidden
            BeginContext(952, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(969, 21, false);
#line 36 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
           Write(Html.Encode(par + ""));

#line default
#line hidden
            EndContext();
            BeginContext(990, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1046, 35, false);
#line 39 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
           Write(Html.DisplayFor(m => i.Obavestenje));

#line default
#line hidden
            EndContext();
            BeginContext(1081, 43, true);
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n\r\n");
            EndContext();
#line 44 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                  
                    var Parms = new Dictionary<string, string>
                                                                                                                                            {
                                                                                                                                                    { "datum",i.Datum.ToString() },
                                                                                                                                                        {"zaposleni",(i.Zaposleni.Ime + i.Zaposleni.Prezime) }
                                                                                                                                            };
                

#line default
#line hidden
            BeginContext(1903, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 52 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                 if ((i.Datum.Year == DateTime.Now.Year && i.Datum.Month == DateTime.Now.Month
         && i.Datum.Day == DateTime.Now.Day))
                {
                    if (i.Kasni == false && (i.VremePrijave.Year == 1389 && i.VremePrijave.Month == 06 && i.VremePrijave.Day == 28))
                    {

#line default
#line hidden
            BeginContext(2224, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2248, 117, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96ec8e4822f24e78b96b20206ec6acf0", async() => {
                BeginContext(2354, 7, true);
                WriteLiteral("Prijava");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 57 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues = Parms;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-all-route-data", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2365, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 58 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                    }
                    else if (i.Kasni == false && !(i.VremePrijave.Year == 1389 && i.VremePrijave.Month == 06 && i.VremePrijave.Day == 28))
                    {

#line default
#line hidden
            BeginContext(2553, 51, true);
            WriteLiteral("                        <h5 style=\"color:green\"><b>");
            EndContext();
            BeginContext(2605, 25, false);
#line 61 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                                              Write(Html.Encode("Prijavljen"));

#line default
#line hidden
            EndContext();
            BeginContext(2630, 11, true);
            WriteLiteral("</b></h5>\r\n");
            EndContext();
#line 62 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(2713, 49, true);
            WriteLiteral("                        <h5 style=\"color:red\"><b>");
            EndContext();
            BeginContext(2763, 20, false);
#line 65 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                                            Write(Html.Encode("Kasni"));

#line default
#line hidden
            EndContext();
            BeginContext(2783, 11, true);
            WriteLiteral("</b></h5>\r\n");
            EndContext();
#line 66 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                    }



                }
                else
                {
                    if (i.Kasni == false && !(i.VremePrijave.Year == 1389 && i.VremePrijave.Month == 06 && i.VremePrijave.Day == 28))
                    {

#line default
#line hidden
            BeginContext(3041, 51, true);
            WriteLiteral("                        <h5 style=\"color:green\"><b>");
            EndContext();
            BeginContext(3093, 25, false);
#line 75 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                                              Write(Html.Encode("Prijavljen"));

#line default
#line hidden
            EndContext();
            BeginContext(3118, 11, true);
            WriteLiteral("</b></h5>\r\n");
            EndContext();
#line 76 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                    }
                    else if (i.Kasni == true && !(i.VremePrijave.Year == 1389 && i.VremePrijave.Month == 06 && i.VremePrijave.Day == 28))
                    {

#line default
#line hidden
            BeginContext(3314, 49, true);
            WriteLiteral("                        <h5 style=\"color:red\"><b>");
            EndContext();
            BeginContext(3364, 20, false);
#line 79 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                                            Write(Html.Encode("Kasni"));

#line default
#line hidden
            EndContext();
            BeginContext(3384, 11, true);
            WriteLiteral("</b></h5>\r\n");
            EndContext();
#line 80 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(3467, 50, true);
            WriteLiteral("                        <h5 style=\"color:blue\"><b>");
            EndContext();
            BeginContext(3518, 36, false);
#line 83 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                                             Write(Html.Encode("Datum/Nije prijavljen"));

#line default
#line hidden
            EndContext();
            BeginContext(3554, 11, true);
            WriteLiteral("</b></h5>\r\n");
            EndContext();
#line 84 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"
                    }

                }

#line default
#line hidden
            BeginContext(3609, 34, true);
            WriteLiteral("            </td>\r\n        </tr>\r\n");
            EndContext();
#line 89 "C:\Users\PC\source\repos\ZaposleniIteh\ZaposleniMVC\Views\Radnik\Vrati.cshtml"

    }

#line default
#line hidden
            BeginContext(3652, 12, true);
            WriteLiteral("    </table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZaposleniMVC.Models.Odgovor> Html { get; private set; }
    }
}
#pragma warning restore 1591
