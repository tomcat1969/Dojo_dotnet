#pragma checksum "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/LingQdemo/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "055f5e7b36c059cd59d3ee21bc5cf337fd3e0418"
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
#line 1 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/LingQdemo/Views/_ViewImports.cshtml"
using LingQdemo;

#line default
#line hidden
#line 2 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/LingQdemo/Views/_ViewImports.cshtml"
using LingQdemo.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"055f5e7b36c059cd59d3ee21bc5cf337fd3e0418", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72eac56ef4e07cb9464b805ddb7e399d90ada07a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<string>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/LingQdemo/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(73, 77, true);
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <ul>\r\n");
            EndContext();
#line 8 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/LingQdemo/Views/Home/Index.cshtml"
         foreach(string element in Model){

#line default
#line hidden
            BeginContext(194, 16, true);
            WriteLiteral("            <li>");
            EndContext();
            BeginContext(211, 7, false);
#line 9 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/LingQdemo/Views/Home/Index.cshtml"
           Write(element);

#line default
#line hidden
            EndContext();
            BeginContext(218, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 10 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/LingQdemo/Views/Home/Index.cshtml"
        }

#line default
#line hidden
            BeginContext(236, 45, true);
            WriteLiteral("            \r\n        \r\n\r\n    </ul>\r\n    <h1>");
            EndContext();
            BeginContext(282, 10, false);
#line 15 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/LingQdemo/Views/Home/Index.cshtml"
   Write(ViewBag.p1);

#line default
#line hidden
            EndContext();
            BeginContext(292, 15, true);
            WriteLiteral("</h1>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
