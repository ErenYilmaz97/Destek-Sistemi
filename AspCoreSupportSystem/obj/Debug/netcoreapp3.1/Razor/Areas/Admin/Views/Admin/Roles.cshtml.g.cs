#pragma checksum "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c67162b9c958f10f00fd411dfdf7f7d33f50868"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admin_Roles), @"mvc.1.0.view", @"/Areas/Admin/Views/Admin/Roles.cshtml")]
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
#line 1 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\_ViewImports.cshtml"
using AspCoreSupportSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\_ViewImports.cshtml"
using AspCoreSupportSystem.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\_ViewImports.cshtml"
using Entities.Dto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\_ViewImports.cshtml"
using AspCoreSupportSystem.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
using Entities.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c67162b9c958f10f00fd411dfdf7f7d33f50868", @"/Areas/Admin/Views/Admin/Roles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65ffc33f498d25c4e1f3aadc7689eef83efb6057", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Admin_Roles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Entities.Entities.Role>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"row mt-5\">\r\n        <div class=\"col-md-3\"></div>\r\n        <div class=\"col-md-6\">\r\n\r\n");
#nullable restore
#line 8 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
              
                if (ViewBag.RoleStatus == "RoleCreated")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success\">\r\n                        <small>Rol Başarıyla Eklendi.</small>\r\n                    </div>\r\n");
#nullable restore
#line 14 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
                }
                else if (ViewBag.RoleStatus == "RoleDeleted")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success\">\r\n                        <small>Rol Başarıyla Silindi.</small>\r\n                    </div>\r\n");
#nullable restore
#line 20 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
                }
                else if (ViewBag.RoleStatus == "RoleNotFound")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-danger\">\r\n                        <small>Rol Bulunamadı.</small>\r\n                    </div>\r\n");
#nullable restore
#line 26 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
                }
                else if (ViewBag.RoleStatus == "RoleUpdated")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success\">\r\n                        <small>Rol Başarıyla Güncellendi.</small>\r\n                    </div>\r\n");
#nullable restore
#line 32 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <table class=\"table table hover\">\r\n                <thead>\r\n                <th class=\"text-center\">Rol</th>\r\n                <th class=\"text-center\">İşlemler</th>\r\n\r\n                </thead>\r\n\r\n                <tbody>\r\n\r\n");
#nullable restore
#line 44 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
                     foreach (Role role in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 47 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
                                               Write(role.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-center\">\r\n                                <a class=\"btn btn-sm btn-dark\"");
            BeginWriteAttribute("href", " href=\"", 1701, "\"", 1741, 2);
            WriteAttributeValue("", 1708, "/Admin/DeleteRole?RoleID=", 1708, 25, true);
#nullable restore
#line 49 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
WriteAttributeValue("", 1733, role.Id, 1733, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sil</a>\r\n                                <a class=\"btn btn-sm btn-dark\"");
            BeginWriteAttribute("href", " href=\"", 1814, "\"", 1854, 2);
            WriteAttributeValue("", 1821, "/Admin/UpdateRole?RoleID=", 1821, 25, true);
#nullable restore
#line 50 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
WriteAttributeValue("", 1846, role.Id, 1846, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Güncelle</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 53 "C:\Users\eren_\Desktop\örnekc#\DestekSistemi\AspCoreSupportSystem\Areas\Admin\Views\Admin\Roles.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n\r\n            <a class=\"btn btn-block btn-dark mt-3\" href=\"/Admin/CreateRole\">Rol Ekle</a>\r\n\r\n        </div>\r\n        <div class=\"col-md-3\"></div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Entities.Entities.Role>> Html { get; private set; }
    }
}
#pragma warning restore 1591
