#pragma checksum "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/RandomPasscode/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c542cdb16446c8929367727792661c9bca032e87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/RandomPasscode/Views/_ViewImports.cshtml"
using RandomPasscode;

#line default
#line hidden
#line 2 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/RandomPasscode/Views/_ViewImports.cshtml"
using RandomPasscode.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c542cdb16446c8929367727792661c9bca032e87", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e42cd7b8af8768fe262a1b538d625ccb9051478f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/RandomPasscode/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 73, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h3 class=\"display-4\">Random passcode (#");
            EndContext();
            BeginContext(119, 13, false);
#line 6 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/RandomPasscode/Views/Home/Index.cshtml"
                                       Write(ViewBag.count);

#line default
#line hidden
            EndContext();
            BeginContext(132, 17, true);
            WriteLiteral(" )</h3>\r\n    <h1>");
            EndContext();
            BeginContext(150, 16, false);
#line 7 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/RandomPasscode/Views/Home/Index.cshtml"
   Write(ViewBag.Passcode);

#line default
#line hidden
            EndContext();
            BeginContext(166, 49, true);
            WriteLiteral("</h1>\r\n    <a href=\"/generate\">TEST</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
