#pragma checksum "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/PartialTest1/Views/Home/NavPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a52c70492648dc4f013c2762003f48a8e0c3a928"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_NavPartial), @"mvc.1.0.view", @"/Views/Home/NavPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/NavPartial.cshtml", typeof(AspNetCore.Views_Home_NavPartial))]
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
#line 1 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/PartialTest1/Views/_ViewImports.cshtml"
using PartialTest1;

#line default
#line hidden
#line 2 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/PartialTest1/Views/_ViewImports.cshtml"
using PartialTest1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a52c70492648dc4f013c2762003f48a8e0c3a928", @"/Views/Home/NavPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"395fdeabc65ffe9207cd0e77e352dce59dcc3958", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_NavPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 120, true);
            WriteLiteral("<nav>\n    <ul>\n        <li><a href=\"/\">Home</a></li>\n        <li><a href=\"/about\">About Me</a></li>\n    </ul>\n</nav>\n<p>");
            EndContext();
            BeginContext(121, 15, false);
#line 7 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/PartialTest1/Views/Home/NavPartial.cshtml"
Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(136, 3, true);
            WriteLiteral(" + ");
            EndContext();
            BeginContext(140, 19, false);
#line 7 "/Users/linhuang/Desktop/CodingDojo/c_sharp_stack/Dojo_dotnet/PartialTest1/Views/Home/NavPartial.cshtml"
                 Write(ViewBag.CurrentTime);

#line default
#line hidden
            EndContext();
            BeginContext(159, 4, true);
            WriteLiteral("</p>");
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
