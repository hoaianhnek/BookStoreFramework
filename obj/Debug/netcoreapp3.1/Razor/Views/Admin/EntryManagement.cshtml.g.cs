#pragma checksum "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e375d278a10a9f20b533d06ddf125564b575544"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EntryManagement), @"mvc.1.0.view", @"/Views/Admin/EntryManagement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e375d278a10a9f20b533d06ddf125564b575544", @"/Views/Admin/EntryManagement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EntryManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/SharedAdmin/_Layout.cshtml";
    float tt = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"right_col\" role=\"main\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 161, "\"", 169, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <div class=""page-title"">
            <div class=""title_left"">
                <h4>ENTRY MANAGEMENT</h4>
            </div>
            <div class=""title_right"">
                <div class=""col-md-5 col-sm-5   form-group pull-right top_search"">
                    <div class=""input-group"">
                        <input type=""text"" class=""form-control"" placeholder=""Search for..."">
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
                        <h2>Entry</h2>
                        <div class=""clearfix""></div>
                    </div");
            WriteLiteral(">\r\n                    <p>\r\n                        ");
#nullable restore
#line 32 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                   Write(Html.ActionLink("Create New", "CreateEntry"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n");
#nullable restore
#line 34 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                     if(TempData["StatusUpdate"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success alert-dismissible\">\r\n                        <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                        ");
#nullable restore
#line 37 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                   Write(TempData["StatusUpdate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 39 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                     if(TempData["StatusCreate"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success alert-dismissible\">\r\n                        <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                        ");
#nullable restore
#line 43 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                   Write(TempData["StatusCreate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 45 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                     if(TempData["StatusDelete"] != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success alert-dismissible\">\r\n                        <button type=\"button\" class=\"close\" data-dismiss = \"alert\">&times;</button>\r\n                        ");
#nullable restore
#line 49 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                   Write(TempData["StatusDelete"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 51 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""x_content"">
                        <table class=""table table-striped b-t b-light"">
                            <thead>
                                <tr>
                                    <th data-breakpoints=""xs"" scope=""col"">ID</th>
                                    <th>Name Supplier</th>
                                    <th>Address</th>
                                    <th>Date Entry</th>
                                    <th>Details Product</th>
                                    <th>SubTotal</th>
                                    <th>Status</th>
                                    <th scope=""col"">Manipulation</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 67 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                 foreach (var item in ViewBag.entry)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td scope=\"row\">");
#nullable restore
#line 70 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                   Write(item.idEntry);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        \r\n");
#nullable restore
#line 72 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                         foreach (var s in ViewBag.supplier)
                                        {
                                            if(s.idSupplier == item.idSupplier) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td><span class=\"text-ellipsis\">");
#nullable restore
#line 75 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                                           Write(s.nameSupplier);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                                <td><span class=\"text-ellipsis\">");
#nullable restore
#line 76 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                                           Write(s.addressSupplier);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n");
#nullable restore
#line 77 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"text-ellipsis\">");
#nullable restore
#line 79 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                                   Write(item.dateEntry.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
                                        <td>
                                            <table width=""auto"" border=""0"">
                                                <tr>
                                                    <td>Name</td>
                                                    <td>Quantity</td>
                                                    <td>Price</td>
                                                </tr>
");
#nullable restore
#line 87 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                 foreach (var d in ViewBag.detail)
                                                {
                                                    if(d.idEntry == item.idEntry) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n                                                        <td>\r\n");
#nullable restore
#line 92 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                             foreach (var b in ViewBag.books)
                                                            {
                                                                if(b.idBook == d.idBook) {
                                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                               Write(b.nameBook);

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                                               
                                                                }
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        </td>\r\n                                                        <td>");
#nullable restore
#line 99 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                       Write(d.quantityEntry);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                        <td>\r\n                                                            <span>");
#nullable restore
#line 101 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                             Write(d.priceEntry);

#line default
#line hidden
#nullable disable
            WriteLiteral("$</span>\r\n                                                        </td>\r\n                                                    </tr>\r\n");
#nullable restore
#line 104 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                    tt += d.quantityEntry*d.priceEntry;
                                                    }
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                \r\n                                            </table>\r\n                                        </td>\r\n                                        <td>");
#nullable restore
#line 110 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                       Write(tt);

#line default
#line hidden
#nullable disable
            WriteLiteral("$</td>\r\n                                        <td>");
#nullable restore
#line 111 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                       Write(item.status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 112 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                         if(item.status == "Delivered") {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><a class=\"btn float-right InvoiceEntrydis\" disabled>Invoice</a></td>\r\n");
#nullable restore
#line 114 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                        } else {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td>\r\n                                            <a class=\"btn float-right InvoiceEntry\" data-id=\"");
#nullable restore
#line 116 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                                                                        Write(item.idEntry);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Invoice</a>\r\n                                            <p class=\"actionAdmin\">\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 6683, "\"", 6722, 2);
            WriteAttributeValue("", 6690, "/Admin/DeleteEntry/", 6690, 19, true);
#nullable restore
#line 118 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
WriteAttributeValue("", 6709, item.idEntry, 6709, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btnSubmit"">
                                                    <i class=""fa fa-trash""></i>
                                                </a>
                                                |
                                                <a");
            BeginWriteAttribute("href", " href=\"", 6980, "\"", 7017, 2);
            WriteAttributeValue("", 6987, "/Admin/EditEntry/", 6987, 17, true);
#nullable restore
#line 122 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
WriteAttributeValue("", 7004, item.idEntry, 7004, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                    <i class=\"fa fa-edit\"></i>\r\n                                                </a>\r\n                                            </p>\r\n                                        </td>\r\n");
#nullable restore
#line 127 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                        }   

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tr>    \r\n");
#nullable restore
#line 129 "C:\xampp\htdocs\frame\Views\Admin\EntryManagement.cshtml"
                                    tt = 0; 
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
