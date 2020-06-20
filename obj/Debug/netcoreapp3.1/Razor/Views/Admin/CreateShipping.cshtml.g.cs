#pragma checksum "C:\xampp\htdocs\frame\Views\Admin\CreateShipping.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fa0d0c85279d9876807e49de7f22b5724f99b43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CreateShipping), @"mvc.1.0.view", @"/Views/Admin/CreateShipping.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fa0d0c85279d9876807e49de7f22b5724f99b43", @"/Views/Admin/CreateShipping.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_CreateShipping : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<frame.Models.Shipping>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \r\n");
#nullable restore
#line 3 "C:\xampp\htdocs\frame\Views\Admin\CreateShipping.cshtml"
  
    ViewBag.Title = "Add Shipping";
    Layout = "~/Views/SharedAdmin/_Layout.cshtml";
    var id = ViewBag.id;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""right_col"" role=""main"">
    <div class=""EditCategory"">
        <div class=""page-title"">
            <div class=""title_left"">
                <h4>SHIPPING MANAGEMENT</h4>
            </div>
        </div>
        <div class=""clearfix""></div>
        <div class=""row"" style=""display: flex"">
            <div class=""col-md-6 col-sm-6  "" style=""height:100vh"">
                <div class=""x_panel"">
                    <div class=""x_title"">
                        <h2>Add Shipping</h2>
                        <div class=""clearfix""></div>
                    </div>
");
#nullable restore
#line 23 "C:\xampp\htdocs\frame\Views\Admin\CreateShipping.cshtml"
                     using (Html.BeginForm())
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\xampp\htdocs\frame\Views\Admin\CreateShipping.cshtml"
                   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\xampp\htdocs\frame\Views\Admin\CreateShipping.cshtml"
                   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""form-row""> 
                            <div class=""form-group col-md-6"">
                                <label class=""font-weight-bold"">ID Shipping</label>
                                <input type=""text"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 1223, "\"", 1234, 1);
#nullable restore
#line 30 "C:\xampp\htdocs\frame\Views\Admin\CreateShipping.cshtml"
WriteAttributeValue("", 1231, id, 1231, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                                <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1299, "\"", 1310, 1);
#nullable restore
#line 31 "C:\xampp\htdocs\frame\Views\Admin\CreateShipping.cshtml"
WriteAttributeValue("", 1307, id, 1307, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""id"" />
                            </div> 
                        </div>
                        <div class=""form-row"">
                            <div class=""form-group col-md-6"">
                                <label class=""font-weight-bold"">Country</label>
                                <input type=""text"" pattern=""^[A-Za-z0-9-\s]*"" title=""Country should without accents"" class=""form-control"" name=""country""");
            BeginWriteAttribute("required", " required=\"", 1739, "\"", 1750, 0);
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""Enter country"">
                            </div>
                        </div>
                        <div class=""form-row"">
                            <div class=""form-group col-md-6"">
                                <label class=""font-weight-bold"">Charge</label>
                                <input type=""text"" title=""Charge should without accents"" class=""form-control"" name=""charge""");
            BeginWriteAttribute("required", " required=\"", 2164, "\"", 2175, 0);
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""Enter charge"">
                            </div>
                        </div>
                        <br>
                        <div class=""modal-footer"">
                            <a href=""../../Admin/ShippingManagement"" name=""submit-cancel"" class=""btn btn-danger"">Cancel</a>
                            <input type=""submit"" name=""submit-save"" class=""btn btn-success"" value=""Save"" />
                        </div>
");
#nullable restore
#line 51 "C:\xampp\htdocs\frame\Views\Admin\CreateShipping.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<frame.Models.Shipping> Html { get; private set; }
    }
}
#pragma warning restore 1591
