#pragma checksum "c:\Users\tomca_000\Desktop\dotnet\MvcDemo1\Views\Home\User.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca91d24b3652bc36f198ff244f5dc2139f2c5c52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_User), @"mvc.1.0.view", @"/Views/Home/User.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/User.cshtml", typeof(AspNetCore.Views_Home_User))]
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
#line 1 "c:\Users\tomca_000\Desktop\dotnet\MvcDemo1\Views\_ViewImports.cshtml"
using MvcDemo1;

#line default
#line hidden
#line 2 "c:\Users\tomca_000\Desktop\dotnet\MvcDemo1\Views\_ViewImports.cshtml"
using MvcDemo1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca91d24b3652bc36f198ff244f5dc2139f2c5c52", @"/Views/Home/User.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62067ab52791a3b8183a47ee1e675dcf0625cdcb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_User : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(13, 31, true);
            WriteLiteral("<h1>here is a User !</h1>\r\n<h1>");
            EndContext();
            BeginContext(45, 15, false);
#line 3 "c:\Users\tomca_000\Desktop\dotnet\MvcDemo1\Views\Home\User.cshtml"
Write(Model.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(60, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(62, 14, false);
#line 3 "c:\Users\tomca_000\Desktop\dotnet\MvcDemo1\Views\Home\User.cshtml"
                Write(Model.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(76, 5, true);
            WriteLiteral("</h1>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
