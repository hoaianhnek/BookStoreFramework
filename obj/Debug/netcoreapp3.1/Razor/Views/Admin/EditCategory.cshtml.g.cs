#pragma checksum "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e4d6fd2aeeb5f7fb07a4abeb053a3858b6cb314"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_EditCategory), @"mvc.1.0.view", @"/Views/Admin/EditCategory.cshtml")]
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
#line 1 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\_ViewImports.cshtml"
using frame;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\_ViewImports.cshtml"
using frame.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e4d6fd2aeeb5f7fb07a4abeb053a3858b6cb314", @"/Views/Admin/EditCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"708e4e3a9a23fd4ed811fb1d18518f4bb2b5726d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_EditCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<frame.Models.Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \r\n");
#nullable restore
#line 3 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
  
    ViewBag.Title = "EditCategory";
    Layout = "~/Views/SharedAdmin/_Layout.cshtml";
    var Category = ViewBag.Category;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
  
    var sessionName = new Byte[20];
    bool ok = Context.Session.TryGetValue("login", out sessionName);
    string result = "";
    User users = null;
    if (ok)
    {
        result = System.Text.Encoding.UTF8.GetString(sessionName);
        users = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(result);
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
 if(users == null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h5 class=\"text-danger mt-5 d-flex justify-content-center\">Bạn không có quyền vào trang này. Vui lòng <a class=\"text-light ml-1\"href=\"../../Admin/AccountAdmin\"> đăng nhập</a></h5>\r\n");
#nullable restore
#line 21 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
} else {  

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""right_col"" role=""main"">
    <div class=""EditCategory"">
        <div class=""page-title"">
            <div class=""title_left"">
                <h4>QUẢN LÝ THỂ LOẠI</h4>
            </div>
        </div>
        <div class=""clearfix""></div>
        <div class=""row"" style=""display: flex"">
            <div class=""col-md-6 col-sm-6  "" style=""height:100vh"">
                <div class=""x_panel"">
                    <div class=""x_title"">
                        <h2>Sửa Thể Loại</h2>
                        <div class=""clearfix""></div>
                    </div>
");
#nullable restore
#line 37 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
                     using (Html.BeginForm())
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
                   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
                   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""form-row""> 
                            <div class=""form-group col-md-6"">
                                <label class=""font-weight-bold"">Mã thể loại</label>
                                <input type=""text"" class=""form-control"" name=""id""");
            BeginWriteAttribute("value", " value=\"", 1797, "\"", 1825, 1);
#nullable restore
#line 44 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
WriteAttributeValue("", 1805, Category.idCategory, 1805, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n                            </div> \r\n                        </div>\r\n                        <div class=\"form-row\">\r\n                            <div class=\"form-group col-md-6\">\r\n");
            WriteLiteral("                                <label class=\"font-weight-bold\">Tên thể loại</label>\r\n                                <input type=\"text\" class=\"form-control\" name=\"name\"");
            BeginWriteAttribute("required", " required=\"", 2470, "\"", 2481, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2482, "\"", 2512, 1);
#nullable restore
#line 52 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
WriteAttributeValue("", 2490, Category.nameCategory, 2490, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            </div>
                        </div>
                        <br>
                        <div class=""modal-footer"">
                            <a href=""../../Admin/CategoryManagement"" name=""submit-cancel"" class=""btn btn-danger"">Hủy</a>
                            <input type=""submit"" name=""submit-save"" class=""btn btn-success"" value=""Lưu"" />
                        </div>
");
#nullable restore
#line 60 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 66 "C:\Users\hoaia\OneDrive\Máy tính\Git\frame\Views\Admin\EditCategory.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<frame.Models.Category> Html { get; private set; }
    }
}
#pragma warning restore 1591
