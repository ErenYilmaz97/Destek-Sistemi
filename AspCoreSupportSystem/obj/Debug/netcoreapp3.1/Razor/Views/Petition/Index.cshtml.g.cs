#pragma checksum "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7b85f82e47e55769d5cf52af9c37890152b304f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Petition_Index), @"mvc.1.0.view", @"/Views/Petition/Index.cshtml")]
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
#line 3 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\_ViewImports.cshtml"
using AspCoreSupportSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\_ViewImports.cshtml"
using AspCoreSupportSystem.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\_ViewImports.cshtml"
using Entities.Dto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7b85f82e47e55769d5cf52af9c37890152b304f", @"/Views/Petition/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"544268a3750244c98f0fedee9b58b30ba76b6e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Petition_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ListPetitionsDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreatePetition", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row mt-5\">\r\n    <div class=\"col-md-2\"></div>\r\n    <div class=\"col-md-8 bg-white border border-dark mb-5\">\r\n");
#nullable restore
#line 6 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
          
            if (ViewBag.PetitionStatus == "PetitionCreated")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-success mt-4\">\r\n                <small>Dilekçe Başarıyla Oluşturuldu.</small>\r\n                </div>\r\n");
#nullable restore
#line 12 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
            }
            else if (ViewBag.PetitionStatus == "ThereIsUnsolvedPetition")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-danger mt-4\">\r\n                    <small>Henüz Sonuçlanmamış Dilekçeniz Var. Sonuçlandıkdan Sonra Yeni Dilekçe Oluşturabilirsiniz.</small>\r\n                </div>\r\n");
#nullable restore
#line 18 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4 class=\"mt-4\">Dilekçeler</h4>\r\n        <small>Toplamda ");
#nullable restore
#line 21 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
                   Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Dilekçe</small>\r\n        <hr/>\r\n\r\n        <h4 class=\"text-right\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7b85f82e47e55769d5cf52af9c37890152b304f5917", async() => {
                WriteLiteral("Yeni Dilekçe");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </h4>\r\n        \r\n        \r\n");
#nullable restore
#line 29 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
         foreach (var petition in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card mb-5 mt-3\">\r\n        <div class=\"card-header\">\r\n            <h5><b>");
#nullable restore
#line 33 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
              Write(petition.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> Tarafından <b>");
#nullable restore
#line 33 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
                                                   Write(petition.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> Tarihinde Oluşturuldu</h5>\r\n");
#nullable restore
#line 34 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
              
                if (petition.Statu == Statu.Gönderildi)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <small>Dilekçe Durumu : <b class=\"text-primary\">Gönderildi</b></small>\r\n");
#nullable restore
#line 38 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
                }
                else if (petition.Statu == Statu.İşlemeAlındı)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <small>Dilekçe Durumu : <b class=\"text-warning\">İşleme Alındı</b></small>\r\n");
#nullable restore
#line 42 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <small>Dilekçe Durumu : <b class=\"text-success\">Çözüldü</b></small>\r\n");
#nullable restore
#line 46 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n        <div class=\"card-body\">\r\n            <p class=\"card-text\">");
#nullable restore
#line 53 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
                            Write(petition.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7b85f82e47e55769d5cf52af9c37890152b304f9939", async() => {
                WriteLiteral("Detay");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1934, "~/Petition/Detail/", 1934, 18, true);
#nullable restore
#line 54 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
AddHtmlAttributeValue("", 1952, petition.PetitionID, 1952, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 57 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Views\Petition\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"col-md-2\"></div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ListPetitionsDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
