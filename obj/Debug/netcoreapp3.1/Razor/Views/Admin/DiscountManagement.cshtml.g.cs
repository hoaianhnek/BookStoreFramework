#pragma checksum "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afa51c2c0f089f46cdbb97b55dc5b454ec1f78be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DiscountManagement), @"mvc.1.0.view", @"/Views/Admin/DiscountManagement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afa51c2c0f089f46cdbb97b55dc5b454ec1f78be", @"/Views/Admin/DiscountManagement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_DiscountManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/SharedAdmin/_Layout.cshtml";
    var discount = ViewBag.discount;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"right_col\" role=\"main\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 180, "\"", 188, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <div class=""page-title"">
            <div class=""title_left"">
                <h4>DISCOUNT MANAGEMENT</h4>
            </div>
            <div class=""title_right"">
                <div class=""col-md-5 col-sm-5   form-group pull-right top_search"">
                    <div class=""input-group"">
                        <input type=""text"" class=""form-control"" id=""searchDiscount"" placeholder=""Search for..."">
                        <span class=""input-group-btn"">
                            <button class=""btn btn-default"" type=""button"">Go!</button>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class=""clearfix""></div>
        <div class=""row"" style=""display: flex;"">
            <div class=""col-md-6 col-sm-6  "" style=""height:100vh"">
                <div class=""x_panel"">
                    <div class=""x_title"">
                        <h2>Discount</h2>
                        <div class=""clearfix""></div>");
            WriteLiteral("\n                    </div>\r\n                     <p>\r\n                        ");
#nullable restore
#line 32 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                   Write(Html.ActionLink("Create New", "AddDiscount"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n");
#nullable restore
#line 34 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                     if(TempData["StatusUpdate"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success alert-dismissible\">\r\n                        <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                        ");
#nullable restore
#line 37 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                   Write(TempData["StatusUpdate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 39 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                     if(TempData["StatusCreate"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success alert-dismissible\">\r\n                        <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                        ");
#nullable restore
#line 43 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                   Write(TempData["StatusCreate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 45 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                     if(TempData["StatusDelete"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success alert-dismissible\">\r\n                        <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                        ");
#nullable restore
#line 49 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                   Write(TempData["StatusDelete"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 51 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""x_content"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Quantity</th>
                                    <th>Date Start</th>
                                    <th>Date End</th>
                                    <th>Number(%)</th>
                                    <th>Manipulation</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 66 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                                 foreach (var d in discount)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <th scope=\"row\">");
#nullable restore
#line 69 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                                                   Write(d.idDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <td>");
#nullable restore
#line 70 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                                       Write(d.nameDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 71 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                                       Write(d.quantityDis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 72 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                                       Write(d.dateStart.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 73 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                                       Write(d.dateEnd.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 74 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                                       Write(d.numberDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class=\"actionAdmin\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3735, "\"", 3777, 2);
            WriteAttributeValue("", 3742, "/Admin/DiscountDelete/", 3742, 22, true);
#nullable restore
#line 76 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
WriteAttributeValue("", 3764, d.idDiscount, 3764, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btnSubmit\">\r\n                                                <i class=\"fa fa-trash\"></i>\r\n                                            </a>\r\n                                            |\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 4019, "\"", 4061, 2);
            WriteAttributeValue("", 4026, "/Admin/UpdateDiscount/", 4026, 22, true);
#nullable restore
#line 80 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
WriteAttributeValue("", 4048, d.idDiscount, 4048, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <i class=\"fa fa-edit\"></i>\r\n                                            </a>\r\n                                        </td>\r\n                                    </tr> \r\n");
#nullable restore
#line 85 "C:\xampp\htdocs\frame\Views\Admin\DiscountManagement.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
