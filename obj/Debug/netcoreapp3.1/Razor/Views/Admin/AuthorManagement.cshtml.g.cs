#pragma checksum "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b658f1a39272ec9774cdf306ce4cdd5d3a3c3b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AuthorManagement), @"mvc.1.0.view", @"/Views/Admin/AuthorManagement.cshtml")]
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
#line 1 "C:\xampp\htdocs\frame\Views\_ViewImports.cshtml"
using frame;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\xampp\htdocs\frame\Views\_ViewImports.cshtml"
using frame.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b658f1a39272ec9774cdf306ce4cdd5d3a3c3b8", @"/Views/Admin/AuthorManagement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AuthorManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<frame.Models.Author>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/SharedAdmin/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"right_col\" role=\"main\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 185, "\"", 193, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <div class=""page-title"">
            <div class=""title_left"">
                <h4>AUTHOR MANAGEMENT</h4>
            </div>
            <div class=""title_right"">
                <div class=""col-md-5 col-sm-5   form-group pull-right top_search"">
                    <div class=""input-group"">
                       <input type=""text"" name=""search"" id=""searchAuthor""class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 596, "\"", 619, 1);
#nullable restore
#line 16 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
WriteAttributeValue("", 604, ViewBag.search, 604, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""Search for..."">
                        <span class=""input-group-btn"">
                            <button class=""btn btn-default"" type=""submit"">Go!</button>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class=""clearfix""></div>
        <div class=""row"" style=""display: flex"">
            <div class=""col-md-6 col-sm-6  "" style=""height:100vh"">
                <div class=""x_panel"">
                    <div class=""x_title"">
                        <h2>AUTHOR</h2>
                        <div class=""clearfix""></div>
                    </div>
                        <p>
                            ");
#nullable restore
#line 33 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                       Write(Html.ActionLink("Create New", "CreateAuthor"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n");
#nullable restore
#line 35 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                         if(TempData["StatusUpdate"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"alert alert-success alert-dismissible\">\r\n                            <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                            ");
#nullable restore
#line 38 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                       Write(TempData["StatusUpdate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 40 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                         if(TempData["StatusCreate"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"alert alert-success alert-dismissible\">\r\n                            <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                            ");
#nullable restore
#line 44 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                       Write(TempData["StatusCreate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 46 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                         if(TempData["StatusDelete"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"alert alert-success alert-dismissible\">\r\n                            <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                            ");
#nullable restore
#line 50 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                       Write(TempData["StatusDelete"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 52 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""x_content"">
                            <table class= ""table"">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Name Author</th>
                                        <th>Image</th>
                                        <th>Describe</th>
                                        <th>Manipulation</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 65 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 69 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                                       Write(item.idAuthor);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 72 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                                       Write(item.nameAuthor);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 3638, "\"", 3672, 2);
            WriteAttributeValue("", 3644, "../../images/", 3644, 13, true);
#nullable restore
#line 75 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
WriteAttributeValue("", 3657, item.imgAuthor, 3657, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 3673, "\"", 3695, 1);
#nullable restore
#line 75 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
WriteAttributeValue("", 3679, item.nameAuthor, 3679, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""78""
                                            height=""92"">
                                        </td>
                                        <td>
                                            <p class = ""content_DesAuthor"">
                                                ");
#nullable restore
#line 80 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                                           Write(item.describeAuthor);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </p>		
                                        </td>
                                            
                                        <td class=""actionAdmin"" style=""width: 100px;"">
                                            <a");
            BeginWriteAttribute("href", " href=\"", 4286, "\"", 4327, 2);
            WriteAttributeValue("", 4293, "/Admin/DeleteAuthor/", 4293, 20, true);
#nullable restore
#line 85 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
WriteAttributeValue("", 4313, item.idAuthor, 4313, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btnSubmit\">\r\n                                                <i class=\"fa fa-trash\"></i>\r\n                                            </a>\r\n                                            |\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 4569, "\"", 4613, 2);
            WriteAttributeValue("", 4576, "../../Admin/EditAuthor/", 4576, 23, true);
#nullable restore
#line 89 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
WriteAttributeValue("", 4599, item.idAuthor, 4599, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <i class=\"fa fa-edit\"></i>\r\n                                            </a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 94 "C:\xampp\htdocs\frame\Views\Admin\AuthorManagement.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>            
            </div>
        </div>
    </div>
</div>
<script>
	$('.btnSubmit').click(function() {
		var x = confirm(""Are you sure you want to delete?"");
		if(x) return true;
		else return false;
	});
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<frame.Models.Author>> Html { get; private set; }
    }
}
#pragma warning restore 1591
